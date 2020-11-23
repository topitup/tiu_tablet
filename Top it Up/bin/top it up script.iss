; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{31F4A59C-2641-48F6-8209-9F4FB0D22E0A}
AppName=Top it Up
AppVersion=1.9
;AppVerName=Top it Up 1.5
AppPublisher=Top it Up
AppPublisherURL=http://www.itopitup.co.za/
AppSupportURL=http://www.itopitup.co.za/
AppUpdatesURL=http://www.itopitup.co.za/
DefaultDirName=C:\Top it Up
DisableDirPage=yes
DefaultGroupName=Top it Up
DisableProgramGroupPage=yes
OutputDir=C:\install
OutputBaseFilename=setup
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Dropbox\Dev\vStream\Desktop App\Top it Up\Top it Up\bin\Release\Top it Up.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Dropbox\Dev\vStream\Desktop App\Top it Up\Top it Up\bin\Release\Top it Up.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Dropbox\Dev\vStream\Desktop App\Top it Up\Top it Up\bin\Release\conf\*"; DestDir: "{app}\conf\"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Dropbox\Dev\vStream\Desktop App\Top it Up\Top it Up\bin\Release\html\*"; DestDir: "{app}\html\"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\Top it Up"; Filename: "{app}\Top it Up.exe"
Name: "{commondesktop}\Top it Up"; Filename: "{app}\Top it Up.exe"; Tasks: desktopicon

