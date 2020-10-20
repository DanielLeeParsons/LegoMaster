using LegoMaster.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace LegoMaster
{
    public class SickleaveFunction
    {

        private readonly pc305Context _context;
        public SickleaveFunction(pc305Context context)
        {
            _context = context;
        }
        [FunctionName("DbTest")]
        [Produces("application/json")]
        public async Task<IActionResult> DBTestGet([HttpTrigger(AuthorizationLevel.Function, "get", Route = "get/{var1}")] HttpRequest req,ILogger log, int var1)

        {
            log.LogInformation("dbcall called");
            //Sickleave returnvalue = null;
            List<Sickleave> returnvalue = new List<Sickleave>();
            try
            {
                
                //returnvalue = _context.Sickleave.FirstOrDefault(x => x.TotalDays > var1);
                returnvalue = _context.Sickleave.Where(x => x.TotalDays > var1).ToList();
                
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Something went wrong DBcall");
                return new UnprocessableEntityObjectResult(new { error = "Error in input" });
            }
           
            return new OkObjectResult(JsonConvert.SerializeObject(returnvalue));
        }


        [FunctionName("DbAddTest")]
        public async Task<IActionResult> DBTestPost([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,CancellationToken cts, ILogger log)
        { 
            log.LogInformation("DB write test");
            try
            {
                string bodyValue = await new StreamReader(req.Body).ReadToEndAsync();
                List<Sickleave> newRecords = JsonConvert.DeserializeObject<List<Sickleave>>(bodyValue);
                foreach (Sickleave newRecord in newRecords)
                {
                    try
                    {
                        var entity = await _context.Sickleave.AddAsync(newRecord, cts);
                        await _context.SaveChangesAsync(cts);
                    }

                    catch (Exception ex)
                    {
                        log.LogError(ex, "Something went wrong adding a record");
                    }
                }
                return new OkResult();
            }
            catch (Exception ex)
            {
                log.LogError(ex, "input data fault");
                return new BadRequestResult();
            }
        }
    }
}



