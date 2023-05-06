using Backend.Core.Interfaces;
using Backend.Core.Models;
using Backend.Infrastructure.Models;
using Backend.Model;
using Backend.Metods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.ConditionalFormatting;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Drawing.Chart.Style;
using OfficeOpenXml.Style;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;


namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {

        private readonly ISessionService serviceSession;
        public SessionController(ISessionService sessionService)
        {
            serviceSession = sessionService;
        }

        [Authorize]
        [HttpGet]
        [Route("report/get/{sessionid}")]
        public async Task<ActionResult<ReportGetDTO>> ReportGet(int sessionid)
        {
            ReportGetDTO res = await serviceSession.ReportGet(sessionid);
            
            if (res == null)
            {
                return NotFound();
            }
            var user = CurrentUser.Get(HttpContext);
            if(user.Role != "admin" && user.ProfileId != res.UserId)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [Authorize]
        [HttpGet]
        [Route("report/download/{sessionid}")]
        public async Task<ActionResult> ReportDownload(int sessionid)
        {
            ReportGetDTO res = await serviceSession.ReportGet(sessionid);
            if (res == null)
            {
                return NotFound();
            }
            var user = CurrentUser.Get(HttpContext);
            if (user.Role != "admin" && user.ProfileId != res.UserId)
            {
                return NotFound();
            }
            byte[] fileBytes = System.IO.File.ReadAllBytes(res.ReportPath);


            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Report {res.SessionId}");
        }


        [NonAction]
        public async Task<byte[]> MakeReport(int sessionid)
        {

            ReportAllData session = await serviceSession.ReportAllData(sessionid);
            
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("Report");

            int row = 1;

            sheet.Cells[row, 1].Value = "Date and Time Session:";
            sheet.Cells[row, 2].Value = session.Datetime;
            row++;

            sheet.Cells[row, 1].Value = "Location:";
            sheet.Cells[row, 2].Value = session.Location;
            row++;

            sheet.Cells[row, 1].Value = "Customer Name:";
            sheet.Cells[row, 2].Value = session.Name;
            row++;

            sheet.Cells[row, 1].Value = "Login:";
            sheet.Cells[row, 2].Value = session.Login;
            row++;
            sheet.Cells[row, 1].Value = "Email:";
            sheet.Cells[row, 2].Value = session.Email;
            row++;
            sheet.Cells[row, 1].Value = "Phone:";
            sheet.Cells[row, 2].Value = session.PhoneNumber;
            row++;

            row++;
            sheet.Cells[row, 1, row, session.DurationMinute + 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
            sheet.Cells[row, 1, row, session.DurationMinute + 2].Merge = true;
            sheet.Cells[row, 1, row, session.DurationMinute + 2].Style.Fill.BackgroundColor.SetColor(Color.Gray);

            row++;

            sheet.Cells[row, 3, row, session.DurationMinute + 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
            sheet.Cells[row, 3, row, session.DurationMinute + 2].Merge = true;
            sheet.Cells[row, 3, row, session.DurationMinute + 2].Style.Fill.BackgroundColor.SetColor(Color.Tomato);
            sheet.Cells[row, 3, row, session.DurationMinute + 2].Style.Border.BorderAround(ExcelBorderStyle.Thin) ;
            sheet.Cells[row, 3, row, session.DurationMinute + 2].Value = "Expect";

            sheet.Cells[row, session.DurationMinute + 4, row, session.DurationMinute + 7].Merge = true;
            sheet.Cells[row, session.DurationMinute + 4, row, session.DurationMinute + 7].Value = "Audience";
            sheet.Cells[row, session.DurationMinute + 4, row, session.DurationMinute + 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            sheet.Cells[row, session.DurationMinute + 4, row, session.DurationMinute + 7].Style.Border.BorderAround(ExcelBorderStyle.Thin);

            row++;

            int rowToAudience = row;


            sheet.Cells[rowToAudience, session.DurationMinute + 4].Value = "AudienceId";
            sheet.Cells[rowToAudience, session.DurationMinute + 5].Value = "Age";
            sheet.Cells[rowToAudience, session.DurationMinute + 6].Value = "Sex";
            sheet.Cells[rowToAudience, session.DurationMinute + 7].Value = "Amount";


            sheet.Cells[rowToAudience, session.DurationMinute + 4, rowToAudience, session.DurationMinute + 7].AutoFitColumns();
            sheet.Cells[rowToAudience, session.DurationMinute + 4, rowToAudience, session.DurationMinute + 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            sheet.Cells[rowToAudience, session.DurationMinute + 4, rowToAudience, session.DurationMinute + 7].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            sheet.Cells[rowToAudience, session.DurationMinute + 4, rowToAudience, session.DurationMinute + 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            sheet.Cells[rowToAudience, session.DurationMinute + 4, rowToAudience, session.DurationMinute + 7].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            sheet.Cells[rowToAudience, session.DurationMinute + 4, rowToAudience, session.DurationMinute + 7].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            rowToAudience++;


            foreach (var audience in session.AudiencePacks)
            {
                sheet.Cells[rowToAudience, session.DurationMinute + 4].Value = audience.AudienceId;
                sheet.Cells[rowToAudience, session.DurationMinute + 5].Value = audience.Age;
                sheet.Cells[rowToAudience, session.DurationMinute + 6].Value = audience.Sex ? "Man" : "Woman";
                sheet.Cells[rowToAudience, session.DurationMinute + 7].Value = audience.AudienceCount;
                sheet.Cells[rowToAudience, session.DurationMinute + 4, rowToAudience, session.DurationMinute + 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                sheet.Cells[rowToAudience, session.DurationMinute + 4, rowToAudience, session.DurationMinute + 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                sheet.Cells[rowToAudience, session.DurationMinute + 4, rowToAudience, session.DurationMinute + 7].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                sheet.Cells[rowToAudience, session.DurationMinute + 4, rowToAudience, session.DurationMinute + 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                sheet.Cells[rowToAudience, session.DurationMinute + 4, rowToAudience, session.DurationMinute + 7].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                sheet.Cells[rowToAudience, session.DurationMinute + 4, rowToAudience, session.DurationMinute + 7].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                rowToAudience++;
            }


            int rowExpectStart = row;

            foreach(var expect in session.EmotionalGet.EmotionalExpect)
            {
                sheet.Cells[row, 1].Value = expect.Sex ? "Man " + expect.Age.ToString() + " y.o." : "Woman " + expect.Age.ToString() + " y.o.";
                sheet.Cells[row, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                sheet.Cells[row, 2].Value = expect.AudienceId;
                sheet.Cells[row, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                int colum = 3;
                foreach(var expectOne in expect.EmotionalEDGetDTO)
                {
                    int lenght = expectOne.End - expectOne.Start;
                    sheet.Cells[row, colum, row, colum + lenght].Merge = true;
                    sheet.Cells[row, colum, row, colum + lenght].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    switch (expectOne.Emotional)
                    {
                        case "Happy":
                            sheet.Cells[row, colum, row, colum + lenght].Style.Fill.BackgroundColor.SetColor(Color.LimeGreen);
                            break;
                        case "Angry":
                            sheet.Cells[row, colum, row, colum + lenght].Style.Fill.BackgroundColor.SetColor(Color.LightCoral);
                            break;
                        case "Sad":
                            sheet.Cells[row, colum, row, colum + lenght].Style.Fill.BackgroundColor.SetColor(Color.RoyalBlue);
                            break;
                        case "Scary":
                            sheet.Cells[row, colum, row, colum + lenght].Style.Fill.BackgroundColor.SetColor(Color.Goldenrod);
                            break;
                        default:
                            sheet.Cells[row, colum, row, colum + lenght].Style.Fill.BackgroundColor.SetColor(Color.Ivory);
                            break;
                    }
                    sheet.Cells[row, colum, row, colum + lenght].Value = expectOne.Emotional;
                    sheet.Cells[row, colum, row, colum + lenght].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    colum += lenght +1 ;
                }
                sheet.Cells[row, colum-1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                row++;
            }
            int rowExpectEnd = row;
            row++;

            sheet.Cells[row, 3, row, session.DurationMinute + 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
            sheet.Cells[row, 3, row, session.DurationMinute + 2].Merge = true;
            sheet.Cells[row, 3, row, session.DurationMinute + 2].Style.Fill.BackgroundColor.SetColor(Color.Lime);

            sheet.Cells[row, 3, row, session.DurationMinute + 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);
            sheet.Cells[row, 3, row, session.DurationMinute + 2].Value = "Result";

            row++;

            int rowResultStart = row;

            foreach (var result in session.EmotionalGet.EmotionalResult)
            {
                sheet.Cells[row, 1].Value = result.Sex ? "Man " + result.Age.ToString() + " y.o." : "Woman " + result.Age.ToString() + " y.o.";
                sheet.Cells[row, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                sheet.Cells[row, 2].Value = result.AudienceId;
                sheet.Cells[row, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                int colum = 3;
                foreach (var resultOne in result.RDGet)
                {
                    int lenght = resultOne.End - resultOne.Start;
                    sheet.Cells[row, colum, row, colum + lenght].Merge = true;
                    sheet.Cells[row, colum, row, colum + lenght].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    switch (resultOne.Emotional)
                    {
                        case "Happy":
                            sheet.Cells[row, colum, row, colum + lenght].Style.Fill.BackgroundColor.SetColor(Color.LimeGreen);
                            break;
                        case "Angry":
                            sheet.Cells[row, colum, row, colum + lenght].Style.Fill.BackgroundColor.SetColor(Color.LightCoral);
                            break;
                        case "Sad":
                            sheet.Cells[row, colum, row, colum + lenght].Style.Fill.BackgroundColor.SetColor(Color.RoyalBlue);
                            break;
                        case "Scary":
                            sheet.Cells[row, colum, row, colum + lenght].Style.Fill.BackgroundColor.SetColor(Color.Goldenrod);
                            break;
                        default:
                            sheet.Cells[row, colum, row, colum + lenght].Style.Fill.BackgroundColor.SetColor(Color.Ivory);
                            break;
                    }
                    sheet.Cells[row, colum, row, colum + lenght].Value = resultOne.Emotional;
                    sheet.Cells[row, colum, row, colum + lenght].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    colum += lenght + 1;
                }
                sheet.Cells[row, colum - 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                row++;
            }

            int rowResultEnd = row;

            row++;

            string startAudience = sheet.Cells[rowResultStart, 2].Address;
            string endAudience = sheet.Cells[rowResultEnd, 2].Address;

            foreach (var audience in session.AudiencePacks)
            {
                sheet.Cells[row, 1].Value = audience.AudienceId;
                sheet.Cells[row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                sheet.Cells[row + 1, 1].Value = audience.Sex ? "Man " + audience.Age.ToString() + " y.o." : "Woman " + audience.Age.ToString() + " y.o.";
                sheet.Cells[row + 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                sheet.Cells[row, 2].Value = "Happy";
                sheet.Cells[row + 1, 2].Value = "Angry";
                sheet.Cells[row + 2, 2].Value = "Sad";
                sheet.Cells[row + 3, 2].Value = "Scary";
                sheet.Cells[row + 4, 2].Value = "None";
                sheet.Cells[row + 5, 2].Value = "Sucsess:";
                var reportDiagram = package.Workbook.Worksheets.Add(sheet.Cells[row + 1, 1].Value.ToString());
                for (int i = 3; i <= session.DurationMinute + 2; i++)
                {
                    string start = sheet.Cells[rowResultStart, i].Address;
                    string end = sheet.Cells[rowResultEnd, i].Address;

                    sheet.Cells[row, i].Formula = "=COUNTIFS(" + start + ":" + end + ", \"Happy\", " + startAudience + ":" + endAudience + "," + sheet.Cells[row, 1].Address + ")";
                    sheet.Cells[row + 1, i].Formula = "=COUNTIFS(" + start + ":" + end + ", \"Angry\", " + startAudience + ":" + endAudience + "," + sheet.Cells[row, 1].Address + ")";
                    sheet.Cells[row + 2, i].Formula = "=COUNTIFS(" + start + ":" + end + ", \"Sad\", " + startAudience + ":" + endAudience + "," + sheet.Cells[row, 1].Address + ")";
                    sheet.Cells[row + 3, i].Formula = "=COUNTIFS(" + start + ":" + end + ", \"Scary\", " + startAudience + ":" + endAudience + "," + sheet.Cells[row, 1].Address + ")";
                    sheet.Cells[row + 4, i].Formula = "=COUNTIFS(" + start + ":" + end + ", \"None\", " + startAudience + ":" + endAudience + "," + sheet.Cells[row, 1].Address + ")";
                    sheet.Cells[row + 5, i].Formula = "=100*VLOOKUP(VLOOKUP(" + sheet.Cells[row, 1].Address + "," + sheet.Cells[rowExpectStart, 2, rowExpectEnd, i].Address + "," + (i - 1).ToString() + ",FALSE)," + sheet.Cells[row, 2, row + 4, i] + "," + (i - 1).ToString() + ",FALSE)/SUM(" + sheet.Cells[row, i, row + 4, i].Address + ")";
                    sheet.Cells[row + 5, i].Style.Numberformat.Format = "#0\\.00%";


                    var chart = (ExcelPieChart)reportDiagram.Drawings.AddChart(sheet.Cells[row + 1, 1].Value.ToString() + " " + (i - 2).ToString() + " minute", OfficeOpenXml.Drawing.Chart.eChartType.Pie);
                    chart.Title.Text = sheet.Cells[row + 1, 1].Value.ToString() + " " + (i - 2).ToString() + " minute";
                    chart.SetPosition((i - 3) * 20 + 1, 0, 0, 0);
                    chart.SetSize(800, 400);
                    var chartData = (ExcelChartSerie)(chart.Series.Add(sheet.Cells[row, i, row + 4, i], sheet.Cells[row, 2, row + 4, 2]));
                    chartData.Header = sheet.Cells[row + 1, 1].Value.ToString() + " " + (i - 2).ToString() + " minute";

                    var sires = (ExcelPieChartSerie)chartData;
                    sires.DataLabel.Font.Bold = true;
                    sires.DataLabel.ShowPercent = true;
                    sires.DataLabel.ShowLeaderLines = true;
                    sires.DataLabel.ShowCategory = true;
                    chart.Legend.Position = eLegendPosition.Top;

                    chart.StyleManager.SetChartStyle(ePresetChartStyle.PieChartStyle3, ePresetChartColors.ColorfulPalette4);
                }

                sheet.Cells[row + 3, 1].Value = "Total Succsess:";
                sheet.Cells[row + 3, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                sheet.Cells[row + 4, 1].Formula = $"=SUM({sheet.Cells[row + 5, 3, row + 5, session.DurationMinute + 2].Address})/{session.DurationMinute} ";
                sheet.Cells[row + 4, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                sheet.Cells[row + 4, 1].Style.Numberformat.Format = "#0\\.00%";

                sheet.Cells[row, 2, row + 5, session.DurationMinute + 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                sheet.Cells[row, 2, row + 5, session.DurationMinute + 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                sheet.Cells[row, 2, row + 5, session.DurationMinute + 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                sheet.Cells[row, 2, row + 5, session.DurationMinute + 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                row += 8;
            }

            

            

            sheet.Cells[1, 2, row + 3, session.DurationMinute + 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            sheet.Cells[1, 2, 6, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            package.Workbook.Calculate();
            sheet.Cells[1, 1, row, 1].AutoFitColumns();
            sheet.Columns[2].Width = 8.43;
            return package.GetAsByteArray();
        }


        [Authorize(Roles = "user")]
        [HttpGet]
        [Route("get/user/{id}")]
        public async Task<ActionResult<SessionGetDTO>> GetSesionUser(int id)
        {
            var user = CurrentUser.Get(HttpContext);
            List<SessionGetDTO> list = await serviceSession.SessionGetByProfile(user.ProfileId);
            SessionGetDTO res = await serviceSession.SessionGetById(id);
            if (res == null)
            {
                return NotFound();
            }
            if (!list.Contains(res))
            {
                return NotFound();
            }
            return Ok(res);
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        [Route("get/byProfile/")]
        public async Task<ActionResult<List<SessionGetDTO>>> SesionsGetbyProfile()
        {
            var user = CurrentUser.Get(HttpContext);
            List<SessionGetDTO> res = await serviceSession.SessionGetByProfile(user.ProfileId);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<SessionGetDTO>> Post(SessionPost Post)
        {
            var userFromJwt = CurrentUser.Get(HttpContext);
            SessionPostDTO DTO = new SessionPostDTO()
            {
                Datetime = Post.Datetime,
                Audiences = Post.Audiences,
                DurationMinute = Post.DurationMinute,
                Location = Post.Location,
                ProfileId = userFromJwt.ProfileId,
                Status = Post.Status,
            };
            SessionGetDTO? res = await serviceSession.SessionPost(DTO);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("get/byProfile/{id}")]
        public async Task<ActionResult<List<SessionGetDTO>>> SesionsGetbyProfile(int id)
        {
            List<SessionGetDTO> res = await serviceSession.SessionGetByProfile(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }


        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<SessionGetDTO>> SesionsGetbyId(int id)
        {
            SessionGetDTO res = await serviceSession.SessionGetById(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }


       
        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<List<SessionGetDTO>>> SesionsGet()
        {
            List<SessionGetDTO> res = await serviceSession.SessionGet();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }


        [Authorize(Roles = "admin")]
        [Authorize]
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool res = await serviceSession.SessionDelete(id);

            return Ok(res);
        }
     
        
        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("report/post/{id}")]
        public async Task<ActionResult<ReportGetDTO>> ReportPost(int id)
        {
            ReportGetDTO res = await serviceSession.ReportPost(id);

            if (res == null)
            {
                return NotFound();
            }
            var report = MakeReport(id);

            System.IO.File.WriteAllBytes($"report/{id}.xlsx", report.Result);

            return Ok(res);
        }

        [Authorize(Roles = "admin")]
        [HttpPatch]
        [Route("update")]
        public async Task<ActionResult<SessionGetDTO>> Patch(SessionPatchDTO Patch)
        {
            SessionGetDTO? res = await serviceSession.SessionPatch(Patch);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

       
      
    }
}
