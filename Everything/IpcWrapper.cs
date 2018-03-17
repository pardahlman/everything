using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Everything
{
  internal class IpcWrapper
  {
    public static string Search
    {
      get => Everything_GetSearchW();
      set => Everything_SetSearchW(value);
    }

    public static bool MatchPath
    {
      get => Everything_GetMatchPath();
      set => Everything_SetMatchPath(value);
    }

    public static bool MatchCase
    {
      get => Everything_GetMatchCase();
      set => Everything_SetMatchCase(value);
    }

    public static bool MatchWholeWord
    {
      get => Everything_GetMatchWholeWord();
      set => Everything_SetMatchWholeWord(value);
    }

    public static bool Regex
    {
      get => Everything_GetRegex();
      set => Everything_SetRegex(value);
    }

    public static uint Max
    {
      get => Everything_GetMax();
      set => Everything_SetMax(value);
    }

    public static uint Offset
    {
      get => Everything_GetOffset();
      set => Everything_SetOffset(value);
    }

    public static uint LastError => Everything_GetLastError();

    public static void Query(bool wait) => Everything_QueryW(wait);

    public static void SortResultsByPath() => Everything_SortResultsByPath();

    public static void Reset() => Everything_Reset();

    public static string GetResultFileName(uint resultIndex) => Everything_GetResultFileName(resultIndex);

    public uint Sort
    {
      get => Everything_GetSort();
      set => Everything_SetSort(value);
    }

    public static uint ReplyId
    {
      get => Everything_GetReplyID();
      set => Everything_SetReplyID(value);
    }

    public static uint GetFileResultCount() => Everything_GetNumFileResults();
    public static uint GetTotalFileResultCount() => Everything_GetTotFileResults();
    public static uint GetFolderResultCount() => Everything_GetNumFolderResults();
    public static uint GetTotalFolderResultCount() => Everything_GetTotFolderResults();
    public static uint GetResultCount() => Everything_GetNumResults();
    public static uint GetTotalResultCount() => Everything_GetTotResults();
    public static bool IsVolumeResult(uint resultIndex) => Everything_IsVolumeResult(resultIndex);
    public static bool IsFolderResult(uint resultIndex) => Everything_IsFolderResult(resultIndex);
    public static bool IsFileResult(uint resultIndex) => Everything_IsFileResult(resultIndex);
    public static void GetResultFullPath(uint index, StringBuilder buffer, uint maxBufferSize) => Everything_GetResultFullPathNameW(index, buffer, maxBufferSize);

    [DllImport("Everything64.dll")]
    private static extern void Everything_SetReplyID(uint nId);
    [DllImport("Everything64.dll")]
    private static extern uint Everything_GetReplyID();

    [DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
    private static extern uint Everything_SetSearchW(string lpSearchString);
    [DllImport("Everything64.dll")]
    private static extern void Everything_SetMatchPath(bool bEnable);
    [DllImport("Everything64.dll")]
    private static extern void Everything_SetMatchCase(bool bEnable);
    [DllImport("Everything64.dll")]
    private static extern void Everything_SetMatchWholeWord(bool bEnable);
    [DllImport("Everything64.dll")]
    private static extern void Everything_SetRegex(bool bEnable);
    [DllImport("Everything64.dll")]
    private static extern void Everything_SetMax(uint dwMax);
    [DllImport("Everything64.dll")]
    private static extern void Everything_SetOffset(uint dwOffset);
    [DllImport("Everything64.dll")]
    private static extern bool Everything_GetMatchPath();
    [DllImport("Everything64.dll")]
    private static extern bool Everything_GetMatchCase();
    [DllImport("Everything64.dll")]
    private static extern bool Everything_GetMatchWholeWord();
    [DllImport("Everything64.dll")]
    private static extern bool Everything_GetRegex();
    [DllImport("Everything64.dll")]
    private static extern uint Everything_GetMax();
    [DllImport("Everything64.dll")]
    private static extern uint Everything_GetOffset();
    [DllImport("Everything64.dll")]
    private static extern string Everything_GetSearchW();
    [DllImport("Everything64.dll")]
    private static extern uint Everything_GetLastError();
    [DllImport("Everything64.dll")]
    private static extern bool Everything_QueryW(bool bWait);
    [DllImport("Everything64.dll")]
    private static extern void Everything_SortResultsByPath();
    [DllImport("Everything64.dll")]
    private static extern uint Everything_GetNumFileResults();
    [DllImport("Everything64.dll")]
    private static extern uint Everything_GetNumFolderResults();
    [DllImport("Everything64.dll")]
    private static extern uint Everything_GetNumResults();
    [DllImport("Everything64.dll")]
    private static extern uint Everything_GetTotFileResults();
    [DllImport("Everything64.dll")]
    private static extern uint Everything_GetTotFolderResults();
    [DllImport("Everything64.dll")]
    private static extern uint Everything_GetTotResults();
    [DllImport("Everything64.dll")]
    private static extern bool Everything_IsVolumeResult(uint nIndex);
    [DllImport("Everything64.dll")]
    private static extern bool Everything_IsFolderResult(uint nIndex);
    [DllImport("Everything64.dll")]
    private static extern bool Everything_IsFileResult(uint nIndex);
    [DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
    private static extern void Everything_GetResultFullPathNameW(uint nIndex, StringBuilder lpString, uint nMaxCount);
    [DllImport("Everything64.dll")]
    private static extern void Everything_Reset();
    [DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
    private static extern string Everything_GetResultFileName(uint nIndex);
    
    // Everything 1.4
    [DllImport("Everything64.dll")]
    private static extern void Everything_SetSort(uint dwSortType);
    [DllImport("Everything64.dll")]
    private static extern uint Everything_GetSort();
    [DllImport("Everything64.dll")]
    private static extern uint Everything_GetResultListSort();
    [DllImport("Everything64.dll")]
    private static extern void Everything_SetRequestFlags(uint dwRequestFlags);
    [DllImport("Everything64.dll")]
    private static extern uint Everything_GetRequestFlags();
    [DllImport("Everything64.dll")]
    private static extern uint Everything_GetResultListRequestFlags();
    [DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
    private static extern string Everything_GetResultExtension(uint nIndex);

    public static bool TryGetResultSize(uint index, out long size) => Everything_GetResultSize(index, out size);
    public static bool TryGetDateCreated(uint index, out long fileTime) => Everything_GetResultDateCreated(index, out fileTime);
    [DllImport("Everything64.dll")]
    private static extern bool Everything_GetResultSize(uint nIndex, out long lpFileSize);
    [DllImport("Everything64.dll")]
    private static extern bool Everything_GetResultDateCreated(uint nIndex, out long lpFileTime);
    [DllImport("Everything64.dll")]
    private static extern bool Everything_GetResultDateModified(uint nIndex, out long lpFileTime);
    [DllImport("Everything64.dll")]
    private static extern bool Everything_GetResultDateAccessed(uint nIndex, out long lpFileTime);
    [DllImport("Everything64.dll")]
    private static extern uint Everything_GetResultAttributes(uint nIndex);
    [DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
    private static extern string Everything_GetResultFileListFileName(uint nIndex);
    [DllImport("Everything64.dll")]
    private static extern uint Everything_GetResultRunCount(uint nIndex);
    [DllImport("Everything64.dll")]
    private static extern bool Everything_GetResultDateRun(uint nIndex, out long lpFileTime);
    [DllImport("Everything64.dll")]
    private static extern bool Everything_GetResultDateRecentlyChanged(uint nIndex, out long lpFileTime);
    [DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
    private static extern string Everything_GetResultHighlightedFileName(uint nIndex);
    [DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
    private static extern string Everything_GetResultHighlightedPath(uint nIndex);
    [DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
    private static extern string Everything_GetResultHighlightedFullPathAndFileName(uint nIndex);
    [DllImport("Everything64.dll")]
    private static extern uint Everything_GetRunCountFromFileName(string lpFileName);
    [DllImport("Everything64.dll")]
    private static extern bool Everything_SetRunCountFromFileName(string lpFileName, uint dwRunCount);
    [DllImport("Everything64.dll")]
    private static extern uint Everything_IncRunCountFromFileName(string lpFileName);
  }
}
