using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagementSystem.Application.Models;
using HospitalManagementSystem.Application.Repositories;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Domain.Models.Department;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Repository
{
    internal class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext _context;
        public TagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateTagAsync(string? tagName)
        {
            Tag tag = new Tag(tagName);
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
        }

        public async Task EditTagAsync(TagDTO tagDTO)
        {
            var tag = await _context.Tags.FindAsync(tagDTO.Id);
            if(tag != null)
            {
                tag.SetName(tagDTO.Name);
                _context.Update(tag);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Tag?> GetTagAsync(Guid id)
            => await _context.Tags.FindAsync(id);

        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task RemoveTagAsync(Guid id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if(tag != null)
            {
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();
            }
        }
    }
}
