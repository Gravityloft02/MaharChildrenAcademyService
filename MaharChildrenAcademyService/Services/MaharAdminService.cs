using MaharChildrenAcademyService.Interfaces;
using MaharChildrenAcademyService.Models;
using MaharChildrenAcademyService.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaharChildrenAcademyService.Services
{
    public class MaharAdminService : BaseService, IMaharAdmin
    {
        readonly MaharChildrenAcademyDBContext _context;

        public MaharAdminService(MaharChildrenAcademyDBContext context)
        {
            _context = context;
        }
        public async Task<bool> AddAlbum(CustomAlbum album)
        {
            var _album = GetAlbum(album);
            _context.Album.Add(_album);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            return false;
        }

        #region Private Functions
        Album GetAlbum(CustomAlbum custom)
        {
            Album album = new Album()
            {
                Date = custom.Date,
                Day = custom.Day,
                Des = custom.Des,
                Flag = custom.Flag,
                Image = custom.Image,
                Name = custom.Name
            };

            return album;
        }

        CustomAlbum GetAlbum(Album album)
        {
            CustomAlbum custom = new CustomAlbum()
            {
                Des = album.Des,
                Day = album.Day,
                Date = (DateTime)album.Date,
                Image = album.Image,
                Flag =(int) album.Flag,
                Name = album.Name,
                Id = album.Id
            };
            return custom;
        }

        #endregion
    }
}
