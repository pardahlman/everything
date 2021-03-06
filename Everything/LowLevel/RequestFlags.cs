﻿namespace Everything.LowLevel
{
  public class RequestFlags
  {
    public const int EVERYTHING_REQUEST_FILE_NAME = 0x00000001;
    public const int EVERYTHING_REQUEST_PATH = 0x00000002;
    public const int EVERYTHING_REQUEST_FULL_PATH_AND_FILE_NAME = 0x00000004;
    public const int EVERYTHING_REQUEST_EXTENSION = 0x00000008;
    public const int EVERYTHING_REQUEST_SIZE = 0x00000010;
    public const int EVERYTHING_REQUEST_DATE_CREATED = 0x00000020;
    public const int EVERYTHING_REQUEST_DATE_MODIFIED = 0x00000040;
    public const int EVERYTHING_REQUEST_DATE_ACCESSED = 0x00000080;
    public const int EVERYTHING_REQUEST_ATTRIBUTES = 0x00000100;
    public const int EVERYTHING_REQUEST_FILE_LIST_FILE_NAME = 0x00000200;
    public const int EVERYTHING_REQUEST_RUN_COUNT = 0x00000400;
    public const int EVERYTHING_REQUEST_DATE_RUN = 0x00000800;
    public const int EVERYTHING_REQUEST_DATE_RECENTLY_CHANGED = 0x00001000;
    public const int EVERYTHING_REQUEST_HIGHLIGHTED_FILE_NAME = 0x00002000;
    public const int EVERYTHING_REQUEST_HIGHLIGHTED_PATH = 0x00004000;
    public const int EVERYTHING_REQUEST_HIGHLIGHTED_FULL_PATH_AND_FILE_NAME = 0x00008000;
  }
}
