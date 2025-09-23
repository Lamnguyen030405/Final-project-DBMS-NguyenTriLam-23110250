using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneStore.Utils
{
    public static class ExceptionHandler
    {
        private static readonly string LogFilePath = Path.Combine(Application.StartupPath, "Logs", "errors.log");

        static ExceptionHandler()
        {
            // Create logs directory if it doesn't exist
            var logDir = Path.GetDirectoryName(LogFilePath);
            if (!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }
        }

        public static void HandleException(Exception ex, string userMessage = null, bool showToUser = true)
        {
            try
            {
                // Log the exception
                LogException(ex);

                // Show user-friendly message
                if (showToUser)
                {
                    var message = userMessage ?? "Đã xảy ra lỗi trong hệ thống. Vui lòng thử lại hoặc liên hệ quản trị viên.";
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                // If logging fails, just show the message
                if (showToUser)
                {
                    MessageBox.Show("Đã xảy ra lỗi nghiêm trọng trong hệ thống.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void LogException(Exception ex)
        {
            try
            {
                var logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {ex.GetType().Name}: {ex.Message}";
                if (ex.InnerException != null)
                {
                    logEntry += $"\nInner Exception: {ex.InnerException.Message}";
                }
                logEntry += $"\nStack Trace: {ex.StackTrace}";
                logEntry += "\n" + new string('-', 80) + "\n";

                File.AppendAllText(LogFilePath, logEntry);
            }
            catch
            {
                // Ignore logging errors
            }
        }

        public static void ShowValidationError(string message)
        {
            MessageBox.Show(message, "Thông tin không hợp lệ",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool ShowConfirmDialog(string message)
        {
            return MessageBox.Show(message, "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
