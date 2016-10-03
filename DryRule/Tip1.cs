//namespace JustOneProject.DryRule
//{
//public class Tip1
//{
//string GetFilePath()
//{
//    return IsForDebug
//        ? $@"{Folder}\{Name}.{Extension}.{VersionNumber}"
//        : $@"{Folder}\{Name}.{Extension}";
//}

//string GetFilePathBetter()
//{
//    var filePath = $@"{Folder}\{Name}.{Extension}";

//    if (IsForDebug)
//    {
//        filePath += $".{VersionNumber}";
//    }

//    return filePath;
//}

//string GetFilePathMaybeBetter()
//{
//    var postfix = IsForDebug
//        ? $".{VersionNumber}"
//        : "";

//    return $@"{Folder}\{Name}.{Extension}{postfix}";
//}
//}
//}