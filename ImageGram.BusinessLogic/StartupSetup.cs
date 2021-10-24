using ImageGram.Core.Interfaces;
using ImageGram.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGram.Core
{
    public static class StartupSetup
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IFileService, StaticFileService>();
            services.AddTransient<IImageService, ImageService>();
        }
    }
}
