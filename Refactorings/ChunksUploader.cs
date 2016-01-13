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
            Exception anyExceptionOnCommunication = null;

            try
            {
                bool uploadSuccess = UploadChunk(uploadId, dataChunk);

                if (uploadSuccess)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                // log
                anyExceptionOnCommunication = ex;
            }

            if (retries <= 0)
            {
                const string message = "One of the chunks could not be uploaded.";

                if (anyExceptionOnCommunication != null)
                {
                    throw new Exception(message, anyExceptionOnCommunication);
                }

                throw new Exception(message);
            }

            UploadChunkRecursive(uploadId, dataChunk, --retries);
        }

        private bool UploadChunk(long uploadId, byte[] dataChunk)
        {
            return false;
        }
    }
}