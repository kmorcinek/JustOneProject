using System;
using System.Collections.Generic;

namespace JustOneProject.Refactorings
{
    public class ChunksUploader
    {
        private const int MaximumNumberOfRetries = 10;

        public void UploadAllChunks(IList<byte[]> chunkedData, long uploadId)
        {
            foreach (var dataChunk in chunkedData)
            {
                var retries = MaximumNumberOfRetries;
                var success = false;
                var uploadPartFailedException = new Exception("Cannot upload part of file");

                do
                {
                    try
                    {
                        bool uploadSuccess = UploadChunk(uploadId, dataChunk);

                        if (!uploadSuccess)
                        {
                            throw uploadPartFailedException;
                        }

                        success = true;
                    }
                    catch (Exception anyExceptionOnCommunication)
                    {
                        retries--;

                        if (retries == 0)
                        {
                            throw new Exception("One of the chunks could not be uploaded.", anyExceptionOnCommunication);
                        }
                    }
                } while (!success);
            }
        }

        public void UploadAllChunksRecursive(IList<byte[]> chunkedData, long uploadId)
        {
            foreach (var dataChunk in chunkedData)
            {
                UploadChunkRecursive(uploadId, dataChunk, MaximumNumberOfRetries);
            }
        }

        private void UploadChunkRecursive(long uploadId, byte[] dataChunk, int retries)
        {
            if (retries <= 0)
            {
                return;
            }

            try
            {
                bool uploadSuccess = UploadChunk(uploadId, dataChunk);

                if (!uploadSuccess)
                {
                    UploadChunkRecursive(uploadId, dataChunk, --retries);
                }
            }
            catch (Exception ex)
            {
                if (retries == 1)
                {
                    throw new Exception("One of the chunks could not be uploaded.", ex);
                }
            }

            UploadChunkRecursive(uploadId, dataChunk, --retries);
        }

        private bool UploadChunk(long uploadId, byte[] dataChunk)
        {
            return false;
        }
    }
}