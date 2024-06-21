using HospitalManagementSystem.Application.Models;
using HospitalManagementSystem.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Services
{
    public interface ITagService
    {
        Task CreateTag(string? tagName);
        Task EditTag(TagDTO tagDTO);
        Task<TagDTO?> GetTagAsync(Guid id);
        Task<IEnumerable<TagDTO>> GetTagsAsync();
        Task RemoveTag(Guid id);
    }
    public class TagService : ITagService
    {
        ITagRepository _tagRepository;
        public TagService(ITagRepository tagRepository)
            => _tagRepository = tagRepository;

        public async Task EditTag(TagDTO tagDTO)
        {
            await _tagRepository.EditTagAsync(tagDTO);
        }

        public async Task CreateTag(string? tagName)
        {
            await _tagRepository.CreateTagAsync(tagName);
        }

        public async Task<TagDTO?> GetTagAsync(Guid id)
        {
            var tag = await _tagRepository.GetTagAsync(id);
            return tag == null ? null : new TagDTO(tag);
        }

        public async Task<IEnumerable<TagDTO>> GetTagsAsync()
        {
            var tags = await _tagRepository.GetTagsAsync();
            return tags.Select(e => new TagDTO(e));
        }

        public async Task RemoveTag(Guid id)
            => await _tagRepository.RemoveTagAsync(id);



    }
}
