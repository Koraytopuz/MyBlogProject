﻿using Microsoft.EntityFrameworkCore;
using MyBlogProject.Business.Interfaces.Repositories;
using MyBlogProject.Business.Repositories;
using MyBlogProject.DataAccess.Context;
using MyBlogProject.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogProject.DataAccess.Repositories
{
    public class CommentRepository : ICommentRepository, IGenericRepository<Comment>
    {
        private readonly MyBlogDbContext _context;

        public CommentRepository(MyBlogDbContext context)
        {
            _context = context;
        }

        // IGenericRepository metodlarını implement et
        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task AddAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
        }

        public async Task UpdateAsync(Comment comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Comment entity)
        {
            _context.Comments.Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync(); // Veritabanına kaydet
        }

        // ICommentRepository metodlarını implement et
        public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId)
        {
            return await _context.Comments.Where(c => c.PostId == postId).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsByUserIdAsync(int userId)
        {
            return await _context.Comments.Where(c => c.Id == userId).ToListAsync();
        }

   

        Task<List<Comment>> IGenericRepository<Comment>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        void IGenericRepository<Comment>.UpdateAsync(Comment entity)
        {
            UpdateAsync(entity);
        }

        public void Delete(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
            }
        }
    }
}
