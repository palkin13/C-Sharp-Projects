﻿using FileProcessingAPI.Helper;
using Microsoft.AspNetCore.StaticFiles;
using System.Security.AccessControl;

namespace FileProcessingAPI.Services
{
    public class ManageImage : IManageImage
    {
        public async Task<string> UploadFile(IFormFile _iformfile)
        {
            string FileName = " ";
            try
            {
                FileInfo _IFileInfo = new FileInfo(_iformfile.FileName);
                FileName = _iformfile.FileName + "_" + DateTime.Now.Ticks.ToString() + _IFileInfo.Extension;
                var _GetFilePath = Common.GetFilePath(FileName);
                using (var _FileStream = new FileStream(_GetFilePath, FileMode.Create))
                {
                    await _iformfile.CopyToAsync(_FileStream);
                }
                return FileName;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public async Task<(byte[], string, string)> DownloadFile(string FileName)
        {
            try
            {
                var _GetFilePath = Common.GetFilePath(FileName);
                var provider = new FileExtensionContentTypeProvider();

                if(!provider.TryGetContentType(_GetFilePath , out var _ContentType))
                {
                    _ContentType = "application/octet-stream";
                }
                var _ReadAllBytesAsync = await File.ReadAllBytesAsync(_GetFilePath);
                return (_ReadAllBytesAsync, _ContentType, Path.GetFileName(_GetFilePath));

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
