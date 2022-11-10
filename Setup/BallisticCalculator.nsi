!include "MUI2.nsh"
!include "x64.nsh"

  Name "Ballistic Caculator"
  OutFile "BallisticCaculatorSetup.exe"
  Unicode True

  ;Default installation folder
  InstallDir "c:\BallisticCaculator"

  ;Get installation folder from registry if available
  InstallDirRegKey HKCU "Software\NikolayGekhtBallisticCaculator" ""

  ;Request application privileges for Windows Vista
  RequestExecutionLevel admin

  !define MUI_ABORTWARNING

  !insertmacro MUI_PAGE_LICENSE "license.txt"
  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_INSTFILES

  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES

  !insertmacro MUI_LANGUAGE "English"

Function .onInit
${If} ${RunningX64}
    SetRegView 64
${EndIf}
FunctionEnd

Function un.onInit
${If} ${RunningX64}
    SetRegView 64
${EndIf}
FunctionEnd


Section "Install"

  SetOutPath "$INSTDIR"

  File /r ".\content\*.*"

  ;Create uninstaller
  WriteUninstaller "$INSTDIR\Uninstall.exe"

  createDirectory "$SMPROGRAMS\NG Ballistic Calculator"
  createShortCut "$SMPROGRAMS\NG Ballistic Calculator\Ballistic Calculator.lnk" "$INSTDIR\BallisticCalculatorNet.exe"
  createShortCut "$SMPROGRAMS\NG Ballistic Calculator\Reticle Editor.lnk" "$INSTDIR\BallisticCalculatorNet.ReticleEditor.exe"
  createShortCut "$SMPROGRAMS\NG Ballistic Calculator\Uninstall Application.lnk" "$INSTDIR\uninstall.exe"
  SetRegView 64
  WriteRegStr HKCU "Software\NGBallisticCaculator" "" $INSTDIR
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\{239bccba-9bc1-4ece-bf7e-e9bd2245c92d}" "DisplayName" "NG Ballistic Calculator"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\{239bccba-9bc1-4ece-bf7e-e9bd2245c92d}" "DisplayVersion" "2.0"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\{239bccba-9bc1-4ece-bf7e-e9bd2245c92d}" "UninstallString" "$INSTDIR\uninstall.exe"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\{239bccba-9bc1-4ece-bf7e-e9bd2245c92d}" "InstallLocation" "$INSTDIR"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\{239bccba-9bc1-4ece-bf7e-e9bd2245c92d}" "Publisher" "Nikolay Gekht"
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\{239bccba-9bc1-4ece-bf7e-e9bd2245c92d}" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\{239bccba-9bc1-4ece-bf7e-e9bd2245c92d}" "NoRepair" 1
SectionEnd

  LangString DESC_Install ${LANG_ENGLISH} "Installation."

  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
    !insertmacro MUI_DESCRIPTION_TEXT Install $(DESC_Install)
  !insertmacro MUI_FUNCTION_DESCRIPTION_END

Section "Uninstall"
  Delete "$INSTDIR\Uninstall.exe"

  RMDIR /r "$INSTDIR"

  RMDir /r "$SMPROGRAMS\NG Ballistic Calculator"
  SetRegView 64
  DeleteRegKey HKCU "Software\NGBallisticCaculator"
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\{239bccba-9bc1-4ece-bf7e-e9bd2245c92d}"
SectionEnd