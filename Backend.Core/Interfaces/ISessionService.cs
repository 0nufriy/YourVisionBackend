using Backend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Interfaces
{
    public interface ISessionService
    {
        Task<SessionGetDTO> SessionPost(SessionPostDTO sessionPostDTO);
        Task<SessionGetDTO> SessionPatch(SessionPatchDTO sessionPatchDTO);
        Task<bool> SessionDelete(int id);
        Task<SessionGetDTO> SessionGetById(int id);
        Task<List<SessionGetDTO>> SessionGet();
        Task<List<SessionGetDTO>> SessionGetByProfile(int id);
        Task<ReportGetDTO> ReportPost(int sessionId);
        Task<ReportGetDTO> ReportGet(int sessionId);

        Task<ReportAllData> ReportAllData(int sessionId);
    }
}
