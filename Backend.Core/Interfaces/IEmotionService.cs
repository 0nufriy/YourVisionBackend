using Backend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Interfaces
{
    public interface IEmotionService
    {
        Task<EmotionalRDGetDTO> PostEmotionalResult(EmotionalResultPostDTO postDTO);
        Task<EmotionalEDGetDTO> PostEmotionalExpect(EmotionalExpectPostDTO postDTO);
        Task<EmotionalGetDTO> GetEmotionals(int sessionsId);
    }
}
