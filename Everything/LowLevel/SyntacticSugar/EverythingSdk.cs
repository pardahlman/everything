using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Everything.LowLevel.SyntacticSugar
{
  public class EverythingSdk
  {
    /// <summary>
    /// The search text to use for the next query
    /// </summary>
    public static string Search
    {
      get => LowLevelSdk.Everything_GetSearch();
      set => LowLevelSdk.Everything_SetSearch(value);
    }

    /// <summary>
    /// Returns the match path state.
    /// </summary>

    public static bool MatchPath
    {
      get => LowLevel.LowLevelSdk.Everything_GetMatchPath();
      set => LowLevel.LowLevelSdk.Everything_SetMatchPath(value);
    }

    /// <summary>
    /// Returns the match case state.
    /// </summary>

    public static bool MatchCase
    {
      get => LowLevel.LowLevelSdk.Everything_GetMatchCase();
      set => LowLevel.LowLevelSdk.Everything_SetMatchCase(value);
    }

    /// <summary>
    /// Returns the match whole word state.
    /// </summary>
    public static bool MatchWholeWord
    {
      get => LowLevel.LowLevelSdk.Everything_GetMatchWholeWord();
      set => LowLevel.LowLevelSdk.Everything_SetMatchWholeWord(value);
    }

    /// <summary>
    /// The regex state.
    /// </summary>
    public static bool Regex
    {
      get => LowLevel.LowLevelSdk.Everything_GetRegex();
      set => LowLevel.LowLevelSdk.Everything_SetRegex(value);
    }

    /// <summary>
    /// The maximum number of results state.
    /// </summary>
    public static uint Max
    {
      get => LowLevelSdk.Everything_GetMax();
      set => LowLevelSdk.Everything_SetMax(value);
    }

    /// <summary>
    /// The first item offset of the available results.
    /// </summary>
    public static uint Offset
    {
      get => LowLevelSdk.Everything_GetOffset();
      set => LowLevelSdk.Everything_SetOffset(value);
    }

    /// <summary>
    /// Gets Everythings version
    /// </summary>
    public static Version Version
    {
      get
      {
        var major = LowLevelSdk.Everything_GetMajorVersion();
        var minor = LowLevelSdk.Everything_GetMinorVersion();
        var revision = LowLevelSdk.Everything_GetRevision();
        var buildNumber = LowLevelSdk.Everything_GetBuildNumber();
        return new Version(Convert.ToInt32(major), Convert.ToInt32(minor), Convert.ToInt32(buildNumber), Convert.ToInt32(revision));
      }
    }

    /// <summary>
    /// The last-error code value.
    /// </summary>
    public static Error LastError => (Error)(int)LowLevelSdk.Everything_GetLastError();

    /// <summary>
    /// Executes an Everything IPC query with the current search state.
    /// </summary>
    /// <param name="wait">Should the function wait for the results or return immediately.
    /// Set this to FALSE to post the IPC Query and return immediately.
    /// Set this to TRUE to send the IPC Query and wait for the results.
    ///</param>
    public static void Query(bool wait) => LowLevel.LowLevelSdk.Everything_QueryW(wait);

    /// <summary>
    /// Resets the result list and search state, freeing any allocated memory by the library.
    /// </summary>
    public static void CleanUp() => LowLevelSdk.Everything_CleanUp();

    /// <summary>
    /// sorts the current results by path, then file name. SortByPath is CPU Intensive.Sorting by path can take several seconds.
    /// </summary>
    public static void SortByPath() => LowLevel.LowLevelSdk.Everything_SortResultsByPath();

    /// <summary>
    /// Returns the number of visible file results
    /// </summary>
    /// <returns>Returns the number of visible file results.</returns>
    public static uint GetFileResultCount() => LowLevel.LowLevelSdk.Everything_GetNumFileResults();

    /// <summary>
    /// Returns the number of visible folder results
    /// </summary>
    /// <returns>Returns the number of visible folder results.</returns>
    public static uint GetFolderResultCount() => LowLevel.LowLevelSdk.Everything_GetNumFolderResults();

    /// <summary>
    /// Returns the number of visible file and folder results
    /// </summary>
    /// <returns>Returns the number of visible file and folder results.</returns>
    public static uint GetResultCount() => LowLevel.LowLevelSdk.Everything_GetNumResults();

    /// <summary>
    /// Returns the total number of file results.
    /// </summary>
    /// <returns>Returns the total number of folder results.</returns>
    public static uint GetTotalFileResultCount() => LowLevel.LowLevelSdk.Everything_GetTotFileResults();

    /// <summary>
    /// Returns the total number of folder results.
    /// </summary>
    /// <returns>Returns the total number of folder results.</returns>
    public static uint GetTotalFolderResultCount() => LowLevel.LowLevelSdk.Everything_GetTotFolderResults();

    /// <summary>
    /// Returns the total number of file and folder results
    /// </summary>
    /// <returns>Returns the total number of file and folder results.</returns>
    public static uint GetTotalResultCount() => LowLevel.LowLevelSdk.Everything_GetTotResults();

    /// <summary>
    /// Determines if the visible result is the root folder of a volume.
    /// </summary>
    /// <param name="resultIndex">Zero based resultIndex of the visible result.</param>
    /// <returns>The function returns TRUE, if the visible result is a volume </returns>
    public static bool IsVolume(uint resultIndex) => LowLevel.LowLevelSdk.Everything_IsVolumeResult(resultIndex);

    /// <summary>
    /// Determines if the visible result is folder.
    /// </summary>
    /// <param name="resultIndex">Zero based resultIndex of the visible result.</param>
    /// <returns>The function returns TRUE, if the visible result is a folder </returns>
    public static bool IsFolder(uint resultIndex) => LowLevel.LowLevelSdk.Everything_IsFolderResult(resultIndex);

    /// <summary>
    /// Determines if the visible result is file.
    /// </summary>
    /// <param name="resultIndex">Zero based resultIndex of the visible result.</param>
    /// <returns>The function returns TRUE, if the visible result is a file </returns>
    public static bool IsFile(uint resultIndex) => LowLevel.LowLevelSdk.Everything_IsFileResult(resultIndex);

    /// <summary>
    /// Retrieves the full path and file name of the visible result.
    /// </summary>
    /// <param name="resultIndex">Zero based resultIndex of the visible result.</param>
    /// <param name="builder">Pointer to the buffer that will receive the text. If the string is as long or longer than the buffer, the string is truncated and terminated with a NULL character.</param>
    public static void GetFullPath(uint resultIndex, StringBuilder builder) => LowLevel.LowLevelSdk.Everything_GetResultFullPathNameW(resultIndex, builder, (uint)builder.Capacity);

    /// <summary>
    /// Resets the result list and search state to the default state, freeing any allocated memory by the library.
    /// </summary>
    public static void Reset() => LowLevel.LowLevelSdk.Everything_Reset();

    /// <summary>
    /// Retrieves the file name part only of the visible result.
    /// </summary>
    /// <param name="resultIndex">Zero based resultIndex of the visible result.</param>
    /// <returns>The function returns a pointer to a null terminated string of TCHARs.</returns>
    public static string GetFileName(uint resultIndex) => LowLevel.LowLevelSdk.Everything_GetResultFileName(resultIndex);

    // Everything 1.4
    public static Sort Sort
    {
      get => (Sort) (int) LowLevel.LowLevelSdk.Everything_GetSort();
      set => LowLevel.LowLevelSdk.Everything_SetSort((uint) value);
    }

    public static RequestFlags RequestFlags
    {
      get => (RequestFlags) (int) LowLevel.LowLevelSdk.Everything_GetRequestFlags();
      set => LowLevel.LowLevelSdk.Everything_SetRequestFlags((uint) value);
    }

    /// <summary>
    /// Returns the actual sort order for the results.
    /// </summary>
    /// <returns></returns>
    public static Sort GetListSort() => (Sort)(int)LowLevel.LowLevelSdk.Everything_GetResultListSort();

    /// <summary>
    /// Returns the flags of available result data.
    /// </summary>
    /// <returns></returns>
    public static RequestFlags GetResultRequestFlags() => (RequestFlags)(int)LowLevel.LowLevelSdk.Everything_GetResultListRequestFlags();

    /// <summary>
    /// Retrieves the target machine of Everything.
    /// </summary>
    public static TargetMachine TargetMachine => (TargetMachine) (int) LowLevelSdk.Everything_GetTargetMachine();

    /// <summary>
    /// retrieves the extension part of a visible result.
    /// </summary>
    /// <param name="resultIndex">Zero based resultIndex of the visible result.</param>
    /// <returns>The function returns a pointer to a null terminated string of TCHARs.</returns>
    public static string GetExtension(uint resultIndex) => LowLevel.LowLevelSdk.Everything_GetResultExtension(resultIndex);

    /// <summary>
    /// Retrieves the size of a visible result.
    /// </summary>
    /// <param name="resultIndex">Zero based resultIndex of the visible result.</param>
    /// <param name="fileSize">Pointer to a LARGE_INTEGER to hold the size of the result.</param>
    /// <returns></returns>
    public static bool TryGetSize(uint resultIndex, out long fileSize) => LowLevel.LowLevelSdk.Everything_GetResultSize(resultIndex, out fileSize);

    /// <summary>
    /// Retrieves the created date of a visible result.
    /// </summary>
    /// <param name="resultIndex">Zero based resultIndex of the visible result.</param>
    /// <param name="created">Pointer to a FILETIME to hold the created date of the result.</param>
    /// <returns></returns>
    public static bool TryGetDateCreated(uint resultIndex, out DateTime created)
    {
      if (LowLevelSdk.Everything_GetResultDateCreated(resultIndex, out var fileTime))
      {
        try
        {
          created = DateTime.FromFileTime(fileTime);
          return true;
        }
        catch (Exception)
        {
          // ignored
        }
      }
      created = default;
      return false;
    }

    /// <summary>
    /// Retrieves the modified date of a visible result.
    /// </summary>
    /// <param name="resultIndex">Zero based resultIndex of the visible result.</param>
    /// <param name="modified">Pointer to a FILETIME to hold the modified date of the result.</param>
    /// <returns></returns>
    public static bool TryGetDateModified(uint resultIndex, out DateTime modified)
    {
      if (LowLevel.LowLevelSdk.Everything_GetResultDateModified(resultIndex, out var fileTime))
      {
        try
        {
          modified = DateTime.FromFileTime(fileTime);
          return true;
        }
        catch (Exception)
        {
          // ignored
        }
      }
      modified = default;
      return false;
    }

    /// <summary>
    /// Retrieves the accessed date of a visible result.
    /// </summary>
    /// <param name="resultIndex">Zero based resultIndex of the visible result.</param>
    /// <param name="accessed">Pointer to a FILETIME to hold the accessed date of the result.</param>
    /// <returns>The function returns non-zero if successful.</returns>
    public static bool TryGetDateAccessed(uint resultIndex, out DateTime accessed)
    {
      if (LowLevelSdk.Everything_GetResultDateAccessed(resultIndex, out var fileTime))
      {
        try
        {
          accessed = DateTime.FromFileTime(fileTime);
          return true;
        }
        catch (Exception)
        {
          // ignored
        }
      }
      accessed = default;
      return false;
    }

    /// <summary>
    /// Retrieves the attributes of a visible result.
    /// </summary>
    /// <param name="resultIndex">Zero based resultIndex of the visible result.</param>
    /// <returns>The function returns zero or more of FILE_ATTRIBUTE_* flags.</returns>
    public static FileAttributes GetAttributes(uint resultIndex) => (FileAttributes)(int)LowLevel.LowLevelSdk.Everything_GetResultAttributes(resultIndex);

    /// <summary>
    /// Retrieves the file list full path and filename of the visible result.
    /// </summary>
    /// <param name="resultIndex">Zero based resultIndex of the visible result.</param>
    /// <returns></returns>
    public static string GetFileListFileName(uint resultIndex) => LowLevel.LowLevelSdk.Everything_GetResultFileListFileName(resultIndex);

    /// <summary>
    /// Retrieves the number of times a visible result has been run from Everything.
    /// </summary>
    /// <param name="resultIndex">Zero based resultIndex of the visible result.</param>
    /// <returns>The function returns the number of times the result has been run from Everything.</returns>
    public static uint GetRunCount(uint resultIndex) => LowLevel.LowLevelSdk.Everything_GetResultRunCount(resultIndex);

    /// <summary>
    /// Retrieves the run date of a visible result.
    /// </summary>
    /// <param name="resultIndex">Zero based resultIndex of the visible result.</param>
    /// <param name="fileTime">Pointer to a FILETIME to hold the recently changed date of the result.</param>
    /// <returns>The function returns non-zero if successful. The function returns 0 if the run date information is unavailable.</returns>
    public static bool TryGetRunDate(uint resultIndex, out long fileTime) => LowLevel.LowLevelSdk.Everything_GetResultDateRun(resultIndex, out fileTime);

    /// <summary>
    /// Retrieves the recently changed date of a visible result.
    /// </summary>
    /// <param name="resultIndex">Zero based resultIndex of the visible result.</param>
    /// <param name="fileTime">Pointer to a FILETIME to hold the recently changed date of the result.</param>
    /// <returns>The function returns non-zero if successful. The function returns 0 if the recently changed date information is unavailable.</returns>
    public static bool TryGetDateRecentlyChanged(uint resultIndex, out long fileTime) => LowLevel.LowLevelSdk.Everything_GetResultDateRecentlyChanged(resultIndex, out fileTime);

    /// <summary>
    /// Retrieves the highlighted full path and file name of the visible result.
    /// </summary>
    /// <param name="resultIndex">Zero based resultIndex of the visible result.</param>
    /// <returns>The function returns a pointer to a null terminated string of TCHARs.</returns>
    public static string GetHighlightedFileName(uint resultIndex) => LowLevel.LowLevelSdk.Everything_GetResultHighlightedFileName(resultIndex);

    /// <summary>
    /// Retrieves the highlighted path part of the visible result.
    /// </summary>
    /// <param name="resultIndex">Zero based resultIndex of the visible result.</param>
    /// <returns>The function returns a pointer to a null terminated string of TCHARs.</returns>
    public static string GetHighlightedPath(uint resultIndex) => LowLevel.LowLevelSdk.Everything_GetResultHighlightedPath(resultIndex);

    /// <summary>
    /// Retrieves the highlighted file name part of the visible result.
    /// </summary>
    /// <param name="resultIndex">Zero based resultIndex of the visible result.</param>
    /// <returns>The highlighted part of the visible file name.</returns>
    public static string GetHighlightedFullPathAndFileName(uint resultIndex) => LowLevel.LowLevelSdk.Everything_GetResultHighlightedFullPathAndFileName(resultIndex);

    /// <summary>
    /// Gets the run count from a specified file in the Everything resultIndex by file name.
    /// </summary>
    /// <param name="fileName">Pointer to a null-terminated string that specifies a fully qualified file name in the Everything resultIndex. </param>
    /// <returns>The function returns the number of times the file has been run from Everything. The function returns 0 if an error occurred.</returns>
    public static uint GetRunCount(string fileName) => LowLevel.LowLevelSdk.Everything_GetRunCountFromFileName(fileName);

    /// <summary>
    /// Sets the run count for a specified file in the Everything resultIndex by file name.
    /// </summary>
    /// <param name="fileName">Pointer to a null-terminated string that specifies a fully qualified file name in the Everything resultIndex. </param>
    /// <param name="runCount">The new run count.</param>
    /// <returns>The function returns non-zero if successful. The function returns 0 if an error occurred</returns>
    public static bool TrySetRunCount(string fileName, uint runCount) => LowLevel.LowLevelSdk.Everything_SetRunCountFromFileName(fileName, runCount);

    /// <summary>
    /// Increments the run count by one for a specified file in the Everything by file name.
    /// </summary>
    /// <param name="fileName">Pointer to a null-terminated string that specifies a fully qualified file name in the Everything resultIndex. </param>
    /// <returns>The function returns the new run count for the specifed file. The function returns 0 if an error occurred.</returns>
    public static uint IncrementRunCount(string fileName) => LowLevel.LowLevelSdk.Everything_IncRunCountFromFileName(fileName);

    /// <summary>
    /// Checks if Everything is running as administrator or as a standard user.
    /// </summary>
    public static bool IsAdmin => LowLevelSdk.Everything_IsAdmin();

    /// <summary>
    /// Checks if Everything is saving settings and data to %APPDATA%\Everything or to the same location as the Everything.exe.
    /// </summary>
    public static bool IsAppData => LowLevelSdk.Everything_IsAppData();

    /// <summary>
    /// Requests Everything to exit.
    /// </summary>
    /// <returns>The function returns non-zero if the exit request was successful.</returns>
    public static bool TryExit() => LowLevelSdk.Everything_Exit();

    /// <summary>
    /// Deletes all run history.
    /// </summary>
    /// <returns>The function returns non-zero if run history is cleared.</returns>
    public static bool TryDeleteHistory() => LowLevelSdk.Everything_DeleteRunHistory();

    /// <summary>
    /// Requests Everything to save the run history to disk. The run history is only saved to disk when you close an Everything search window or exit Everything.
    /// </summary>
    /// <returns>The function returns non-zero if the request to save the run history to disk was successful.</returns>
    public static bool TrySaveHistory() => LowLevelSdk.Everything_SaveRunHistory();

    /// <summary>
    /// Checks if the database has been fully loaded.
    /// </summary>
    public static bool IsDbLoaded => LowLevelSdk.Everything_IsDBLoaded();

    /// <summary>
    /// Checks if the specified file information is indexed.
    /// </summary>
    /// <param name="fileInfo">The file info type.</param>
    /// <returns>The function returns non-zero if the specified information is indexed</returns>
    public static bool IsInfoIndexed(FileInfoType fileInfo) => LowLevelSdk.Everything_IsFileInfoIndexed((uint)fileInfo);
  }
}
