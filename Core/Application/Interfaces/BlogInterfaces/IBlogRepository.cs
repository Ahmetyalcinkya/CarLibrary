﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        List<Blog> GetLastThreeBlogsWithAuthors();
        List<Blog> GetAllBlogsWithAuthor();
        List<Blog> GetBlogsAuthorById(int id);
    }
}
