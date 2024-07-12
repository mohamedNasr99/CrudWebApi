﻿using bookproject.Data;
using bookproject.DTOs;
using bookproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace bookproject.Services
{
    public class BookService : GenericRepository<Book>, IBookService
    {
        private new readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<responseDto> addAsync([FromQuery]bookDto bookDto)
        {
            Book book = new Book { Title = bookDto.Title, AuthorId = bookDto.authorId, CategoryId = bookDto.categoryId };

            await _context.Books.AddAsync(book);

            var res = await _context.SaveChangesAsync();

            if (res == 1)
            {
                return new responseDto
                {
                    statusCode = 200,
                    isSuccess = true,
                    message = "successfully",
                    model = bookDto
                };
            }

            return new responseDto
            {
                statusCode = 400,
                isSuccess = false,
                message = "Not successfully",
                model = null
            };

        }

        public async Task<responseDto> deleteAsync(int Id)
        {
            var book = await _context.Books.FindAsync(Id);

            if (book != null)
            {
                _context.Books.Remove(book);

                _context.SaveChanges();

                return new responseDto
                {
                    statusCode = 200,
                    isSuccess = true,
                    message = "successfully",
                    model = book
                };
            }

            return new responseDto
            {
                statusCode = 400,
                isSuccess = false,
                message = "Not successfully",
                model = null
            };
        }

        public async Task<responseDto> getAllAsync()
        {
            var authors = await _context.Books.ToListAsync();

            if (authors != null)
            {
                return new responseDto
                {
                    statusCode = 200,
                    isSuccess = true,
                    message = "There are books",
                    model = authors
                };
            }

            return new responseDto
            {
                statusCode = 204,
                isSuccess = false,
                message = "There are no books",
                model = null
            };
        }

        public async Task<responseDto> getByIdAsync(int Id)
        {
            var book = await _context.Books.FindAsync(Id);

            if (book != null)
            {
                return new responseDto
                {
                    statusCode = 200,
                    isSuccess = true,
                    message = "successfully",
                    model = book
                };
            }

            return new responseDto
            {
                statusCode = 400,
                isSuccess = false,
                message = "There is no book with this Id",
                model = null
            };
        }

        public async Task<responseDto> updateByIdAsync(int Id, [FromQuery]bookDto bookDto)
        {
            var book = await _context.Books.FindAsync(Id);

            if (book != null)
            {
                book.Title = bookDto.Title;

                _context.Books.Update(book);

                _context.SaveChanges();

                return new responseDto
                {
                    statusCode = 200,
                    isSuccess = true,
                    message = "Successfully",
                    model = bookDto
                };
            }

            return new responseDto
            {
                statusCode = 400,
                isSuccess = false,
                message = "There is no book with this Id",
                model = null
            };
        }
    }
}