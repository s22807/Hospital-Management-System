using HospitalManagementSystem.Application.Models;
using HospitalManagementSystem.Domain.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Repositories
{
    public interface ITagRepository
    {
        Task CreateTagAsync(string? tagName);
        Task EditTagAsync(TagDTO tagDTO);
        Task<Tag?> GetTagAsync(Guid id);
        Task<IEnumerable<Tag>> GetTagsAsync();
        Task RemoveTagAsync(Guid id);
    }
}
