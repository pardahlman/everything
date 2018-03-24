using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Everything.LowLevel
{
  public class LowLevelSdk
  {
    private const string _everythingDll = "Everything64.dll";

    [DllImport(_everythingDll, CharSet = CharSet.Unicode)]
    public static extern void Everything_SetSearch(string lpSearchString);
    [DllImport(_everythingDll)]
    public static extern void Everything_SetMatchPath(bool bEnable);
    [DllImport(_everythingDll)]
    public static extern void Everything_SetMatchCase(bool bEnable);
    [DllImport(_everythingDll)]
    public static extern void Everything_SetMatchWholeWord(bool bEnable);
    [DllImport(_everythingDll)]
    public static extern void Everything_SetRegex(bool bEnable);
    [DllImport(_everythingDll)]
    public static extern void Everything_SetMax(uint dwMax);
    [DllImport(_everythingDll)]
    public static extern void Everything_SetOffset(uint dwOffset);
    [DllImport(_everythingDll)]
    public static extern bool Everything_GetMatchPath();
    [DllImport(_everythingDll)]
    public static extern bool Everything_GetMatchCase();
    [DllImport(_everythingDll)]
    public static extern bool Everything_GetMatchWholeWord();
    [DllImport(_everythingDll)]
    public static extern bool Everything_GetRegex();
    [DllImport(_everythingDll)]
    public static extern uint Everything_GetMax();
    [DllImport(_everythingDll)]
    public static extern uint Everything_GetOffset();
    [DllImport(_everythingDll, CharSet = CharSet.Unicode)]
    public static extern string Everything_GetSearch();
    [DllImport(_everythingDll)]
    public static extern uint Everything_GetLastError();
    [DllImport(_everythingDll)]
    public static extern bool Everything_QueryW(bool bWait);
    [DllImport(_everythingDll)]
    public static extern void Everything_SortResultsByPath();
    [DllImport(_everythingDll)]
    public static extern uint Everything_GetNumFileResults();
    [DllImport(_everythingDll)]
    public static extern uint Everything_GetNumFolderResults();
    [DllImport(_everythingDll)]
    public static extern uint Everything_GetNumResults();
    [DllImport(_everythingDll)]
    public static extern uint Everything_GetTotFileResults();
    [DllImport(_everythingDll)]
    public static extern uint Everything_GetTotFolderResults();
    [DllImport(_everythingDll)]
    public static extern uint Everything_GetTotResults();
    [DllImport(_everythingDll)]
    public static extern bool Everything_IsVolumeResult(uint nIndex);
    [DllImport(_everythingDll)]
    public static extern bool Everything_IsFolderResult(uint nIndex);
    [DllImport(_everythingDll)]
    public static extern bool Everything_IsFileResult(uint nIndex);
    [DllImport(_everythingDll, CharSet = CharSet.Unicode)]
    public static extern void Everything_GetResultFullPathNameW(uint nIndex, StringBuilder lpString, uint nMaxCount);
    [DllImport(_everythingDll)]
    public static extern void Everything_Reset();
    [DllImport(_everythingDll, CharSet = CharSet.Unicode)]
    public static extern string Everything_GetResultFileName(uint nIndex);
    [DllImport(_everythingDll)]
    public static extern uint Everything_GetMajorVersion();
    [DllImport(_everythingDll)]
    public static extern uint Everything_GetMinorVersion();
    [DllImport(_everythingDll)]
    public static extern uint Everything_GetRevision();
    [DllImport(_everythingDll)]
    public static extern uint Everything_GetBuildNumber();
    [DllImport(_everythingDll)]
    public static extern uint Everything_CleanUp();

    // Everything 1.4
    [DllImport(_everythingDll)]
    public static extern void Everything_SetSort(uint dwSortType);
    [DllImport(_everythingDll)]
    public static extern uint Everything_GetSort();
    [DllImport(_everythingDll)]
    public static extern uint Everything_GetResultListSort();
    [DllImport(_everythingDll)]
    public static extern void Everything_SetRequestFlags(uint dwRequestFlags);
    [DllImport(_everythingDll)]
    public static extern uint Everything_GetRequestFlags();
    [DllImport(_everythingDll)]
    public static extern uint Everything_GetResultListRequestFlags();
    [DllImport(_everythingDll, CharSet = CharSet.Unicode)]
    public static extern string Everything_GetResultExtension(uint nIndex);
    [DllImport(_everythingDll)]
    public static extern bool Everything_GetResultSize(uint nIndex, out long lpFileSize);
    [DllImport(_everythingDll)]
    public static extern bool Everything_GetResultDateCreated(uint nIndex, out long lpFileTime);
    [DllImport(_everythingDll)]
    public static extern bool Everything_GetResultDateModified(uint nIndex, out long lpFileTime);
    [DllImport(_everythingDll)]
    public static extern bool Everything_GetResultDateAccessed(uint nIndex, out long lpFileTime);
    [DllImport(_everythingDll)]
    public static extern uint Everything_GetResultAttributes(uint nIndex);
    [DllImport(_everythingDll, CharSet = CharSet.Unicode)]
    public static extern string Everything_GetResultFileListFileName(uint nIndex);
    [DllImport(_everythingDll)]
    public static extern uint Everything_GetResultRunCount(uint nIndex);
    [DllImport(_everythingDll)]
    public static extern bool Everything_GetResultDateRun(uint nIndex, out long lpFileTime);
    [DllImport(_everythingDll)]
    public static extern bool Everything_GetResultDateRecentlyChanged(uint nIndex, out long lpFileTime);
    [DllImport(_everythingDll, CharSet = CharSet.Unicode)]
    public static extern string Everything_GetResultHighlightedFileName(uint nIndex);
    [DllImport(_everythingDll, CharSet = CharSet.Unicode)]
    public static extern string Everything_GetResultHighlightedPath(uint nIndex);
    [DllImport(_everythingDll, CharSet = CharSet.Unicode)]
    public static extern string Everything_GetResultHighlightedFullPathAndFileName(uint nIndex);
    [DllImport(_everythingDll)]
    public static extern uint Everything_GetRunCountFromFileName(string lpFileName);
    [DllImport(_everythingDll)]
    public static extern bool Everything_SetRunCountFromFileName(string lpFileName, uint dwRunCount);
    [DllImport(_everythingDll)]
    public static extern uint Everything_IncRunCountFromFileName(string lpFileName);
    [DllImport(_everythingDll)]
    public static extern bool Everything_IsAdmin();
    [DllImport(_everythingDll)]
    public static extern bool Everything_IsAppData();
    [DllImport(_everythingDll)]
    public static extern bool Everything_Exit();
    [DllImport(_everythingDll)]
    public static extern bool Everything_DeleteRunHistory();
    [DllImport(_everythingDll)]
    public static extern bool Everything_SaveRunHistory();
    [DllImport(_everythingDll)]
    public static extern bool Everything_IsDBLoaded();
    [DllImport(_everythingDll)]
    public static extern uint Everything_GetTargetMachine();
    [DllImport(_everythingDll)]
    public static extern bool Everything_IsFileInfoIndexed(uint fileInfoType);
  }
}
