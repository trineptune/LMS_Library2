﻿namespace FileWebApi.DTO
{
    public class FileDTO
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public double FileLength { get; set; }
        public int UserId { get; set; }
        public DateTime LastUpdated { get; set; }
        public string FilePath { get; set; }

        public int SubjectId { get; set; }
    }
}
