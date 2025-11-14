; Script generado por el Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!
#define MyAppName "PetroStop_502ag"
#define MyAppVersion "1.5"
#define MyAppPublisher "Agustín Gatica"
#define MyAppExeName "GUI.exe"
#define SqlCmdPath "{commonpf64}\Microsoft SQL Server\Client SDK\ODBC\170\Tools\Binn"

[Setup]
; Identificación
AppId={{73930AC4-1CD7-4558-96D5-85597C4577CF}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
; Directorios
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName} 
CreateAppDir=yes
DisableProgramGroupPage=yes
UninstallDisplayIcon={app}\{#MyAppExeName}
; Privilegios (CRÍTICO para SQL LocalDB)
PrivilegesRequired=admin 
; Compilador
OutputDir=D:\InnoPrograma
OutputBaseFilename=PetroStop_Setup_502ag
SolidCompression=yes
WizardStyle=modern
SetupIconFile=D:\GitHub\TrabajoCampo\TrabajoCampo\GUI\GUI\bin\Debug\Resources\logo.ico

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Dirs]
Name: "{localappdata}\{#MyAppName}"

[Files]
Source: "D:\GitHub\TrabajoCampo\TrabajoCampo\GUI\GUI\bin\Debug\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\GitHub\TrabajoCampo\TrabajoCampo\GUI\GUI\bin\Debug\*"; DestDir: "{app}"; Excludes: "*.pdb, *.vshost.*, scriptBD_502ag.sql, Lenguajes\*"; Flags: ignoreversion
Source: "D:\GitHub\TrabajoCampo\TrabajoCampo\GUI\GUI\bin\Debug\Lenguajes\*"; DestDir: "{app}\Lenguajes"; Flags: recursesubdirs createallsubdirs
Source: "D:\GitHub\TrabajoCampo\TrabajoCampo\GUI\GUI\bin\Debug\Resources\*"; DestDir: "{app}\Resources"; Flags: recursesubdirs createallsubdirs
Source: "D:\GitHub\TrabajoCampo\TrabajoCampo\GUI\GUI\bin\Debug\SqlLocalDB.msi"; DestDir: "{tmp}"; Flags: deleteafterinstall
Source: "D:\GitHub\TrabajoCampo\TrabajoCampo\GUI\GUI\bin\Debug\VC_redist.x64.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall
Source: "D:\GitHub\TrabajoCampo\TrabajoCampo\GUI\GUI\bin\Debug\scriptBD_502ag.sql"; DestDir: "{app}"; Flags: deleteafterinstall
Source: "D:\GitHub\TrabajoCampo\TrabajoCampo\GUI\GUI\bin\Debug\scriptCrearSoloBD_502ag.sql"; DestDir: "{app}"; Flags: deleteafterinstall
Source: "D:\GitHub\TrabajoCampo\TrabajoCampo\GUI\GUI\bin\Debug\scriptDropBD_502ag.sql"; DestDir: "{app}"; Flags: deleteafterinstall
Source: "D:\GitHub\TrabajoCampo\TrabajoCampo\GUI\GUI\bin\Debug\MsSqlCmdLnUtils.msi"; DestDir: "{tmp}"; Flags: deleteafterinstall
Source: "D:\GitHub\TrabajoCampo\TrabajoCampo\GUI\GUI\bin\Debug\msodbcsql.msi"; DestDir: "{tmp}"; Flags: deleteafterinstall
Source: "D:\GitHub\TrabajoCampo\TrabajoCampo\GUI\GUI\bin\Debug\Resources\logo.ico"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\GitHub\TrabajoCampo\TrabajoCampo\GUI\DAL_502ag\DAL.config"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\logo.ico"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon; IconFilename: "{app}\logo.ico"

[Code]
var
  CurrentWindowsUser: String;
  RestoreDatabase: Boolean;
  UserHasBeenAsked: Boolean;
  PerformDbSetup: Boolean; 
  // NUEVO: Variables para la página personalizada y los controles
  SqlConfigPage: TWizardPage;
  InfoLabel: TNewStaticText;
  ExistingInstanceRadio, LocalDBRadio: TNewRadioButton;
  InstanceCombo: TNewComboBox;
  // NUEVO: Variable para almacenar la instancia de SQL seleccionada por el usuario
  SelectedSQLInstance: String;

// Forward declarations
function IsDatabaseMissing(): Boolean; forward;
function NeedsDatabaseRestore(): Boolean; forward;
function GetCreateDbScriptPath(Param: String): String; forward;
function ShouldPerformDbSetup(): Boolean; forward;
// NUEVO: Forward declarations para las nuevas funciones
function GetSelectedInstance(Param: String): String; forward;
function IsLocalDbSelected(): Boolean; forward;

// NUEVO: Evento que se dispara al hacer clic en los radio buttons de la página
procedure SqlOptionClick(Sender: TObject);
begin
  // Habilita el combobox solo si se elige una instancia existente
  InstanceCombo.Enabled := ExistingInstanceRadio.Checked;
end;

// --- NUEVA FUNCIÓN GLOBAL ---
function ArrayIndexOf(var Arr: TArrayOfString; const Value: String): Integer;
var
  J: Integer;
begin
  Result := -1;
  for J := 0 to GetArrayLength(Arr) - 1 do
  begin
    if CompareText(Arr[J], Value) = 0 then
    begin
      Result := J;
      Exit;
    end;
  end;
end;

// --- PROCEDIMIENTO PRINCIPAL ---
procedure PopulateSqlInstances;
var
  InstanceNames, TempNames: TArrayOfString;
  I: Integer;
  ServerName: String;
  Success: Boolean;
begin
  // Llamadas al registro
  Success := RegGetValueNames(HKLM, 'SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL', InstanceNames);
  Success := RegGetValueNames(HKLM64, 'SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL', TempNames);

  // Combinar ambas listas sin duplicados
  for I := 0 to GetArrayLength(TempNames) - 1 do
  begin
    if ArrayIndexOf(InstanceNames, TempNames[I]) = -1 then
    begin
      SetArrayLength(InstanceNames, GetArrayLength(InstanceNames) + 1);
      InstanceNames[GetArrayLength(InstanceNames) - 1] := TempNames[I];
    end;
  end;

  // Poblar el combo con los nombres de instancia
  if GetArrayLength(InstanceNames) > 0 then
  begin
    ServerName := ExpandConstant('{computername}');
    for I := 0 to GetArrayLength(InstanceNames) - 1 do
    begin
      if CompareText(InstanceNames[I], 'MSSQLSERVER') = 0 then
        InstanceCombo.Items.Add(ServerName)
      else
        InstanceCombo.Items.Add(ServerName + '\' + InstanceNames[I]);
    end;
  end;

  // Lógica de selección por defecto
  if InstanceCombo.Items.Count > 0 then
  begin
    InstanceCombo.ItemIndex := 0;
    ExistingInstanceRadio.Checked := True;
    LocalDBRadio.Checked := False;
  end
  else
  begin
    ExistingInstanceRadio.Enabled := False;
    InstanceCombo.Enabled := False;
    LocalDBRadio.Checked := True;
  end;

  SqlOptionClick(nil);
end;

// NUEVO: Evento que se ejecuta al hacer clic en el botón "Siguiente" en la página personalizada
function SqlConfigPage_NextButtonClick(Page: TWizardPage): Boolean;
begin
  if ExistingInstanceRadio.Checked and (InstanceCombo.Text = '') then
  begin
    MsgBox('Por favor, seleccione una instancia de SQL Server de la lista.', mbError, MB_OK);
    Result := False;
  end
  else
  begin
    if LocalDBRadio.Checked then
      SelectedSQLInstance := '(LocalDB)\MSSQLLocalDB'
    else
      SelectedSQLInstance := InstanceCombo.Text;
    
    Log(Format('Instancia de SQL seleccionada: %s', [SelectedSQLInstance]));
    Result := True;
  end;
end;

// NUEVO: Procedimiento para crear la página personalizada y sus controles
procedure CreateSqlConfigPage();
begin
  SqlConfigPage := CreateCustomPage(wpReady, 'Configuración de la Base de Datos', 'Seleccione dónde instalar la base de datos.');

  InfoLabel := TNewStaticText.Create(SqlConfigPage);
  InfoLabel.Caption := 'El programa necesita una base de datos para funcionar. Por favor, elija una opción:';
  InfoLabel.Parent := SqlConfigPage.Surface;
  InfoLabel.Top := 0;
  InfoLabel.Left := 0;
  InfoLabel.Width := SqlConfigPage.SurfaceWidth;
  InfoLabel.AutoSize := False;
  InfoLabel.WordWrap := True;

  // Opción 1: Usar una instancia existente
  ExistingInstanceRadio := TNewRadioButton.Create(SqlConfigPage);
  ExistingInstanceRadio.Parent := SqlConfigPage.Surface;
  ExistingInstanceRadio.Top := InfoLabel.Top + InfoLabel.Height + 15;
  ExistingInstanceRadio.Left := 0;
  ExistingInstanceRadio.Caption := 'Usar una instancia de SQL Server existente:';
  ExistingInstanceRadio.OnClick := @SqlOptionClick;
  ExistingInstanceRadio.Width := SqlConfigPage.SurfaceWidth - 20; 

  InstanceCombo := TNewComboBox.Create(SqlConfigPage);
  InstanceCombo.Parent := SqlConfigPage.Surface;
  InstanceCombo.Top := ExistingInstanceRadio.Top + ExistingInstanceRadio.Height;
  InstanceCombo.Left := 20;
  InstanceCombo.Width := SqlConfigPage.SurfaceWidth;
  InstanceCombo.Style := csDropDownList;

  // Opción 2: Instalar una nueva instancia LocalDB
  LocalDBRadio := TNewRadioButton.Create(SqlConfigPage);
  LocalDBRadio.Parent := SqlConfigPage.Surface;
  LocalDBRadio.Top := InstanceCombo.Top + InstanceCombo.Height + 10;
  LocalDBRadio.Left := 0;
  LocalDBRadio.Width := SqlConfigPage.SurfaceWidth; 
  LocalDBRadio.Caption := 'Instalar y usar LocalDB (PARA NADA RECOMENDADO EN EL AULA 334 DE LA UAI)';
  LocalDBRadio.Checked := True; // Opción por defecto
  LocalDBRadio.OnClick := @SqlOptionClick;
  
  // Asocia el evento NextButtonClick a la página
  SqlConfigPage.OnNextButtonClick := @SqlConfigPage_NextButtonClick;

  PopulateSqlInstances();
end;


// --- NUEVA FUNCIÓN DE REEMPLAZO MANUAL ---
function ManualStringReplace(const Source, Substring, Replacement: String): String;
var
  Position: Integer;
  ResultStr: String;
begin
  // Busca la posición del texto a reemplazar
  Position := Pos(Substring, Source);

  // Si se encuentra...
  if Position > 0 then
  begin
    // 1. Copia todo lo que está ANTES del marcador
    ResultStr := Copy(Source, 1, Position - 1);
    // 2. Añade el nuevo texto (la instancia de SQL)
    ResultStr := ResultStr + Replacement;
    // 3. Añade todo lo que estaba DESPUÉS del marcador
    ResultStr := ResultStr + Copy(Source, Position + Length(Substring), Length(Source));
  end
  else
  begin
    // Si no se encuentra, devuelve el texto original sin cambios
    ResultStr := Source;
  end;

  Result := ResultStr;
end;


procedure UpdateConnectionString;
var
  ConfigPath: String;
  Lines: TStringList;
  I: Integer;
  CurrentLine: String;
begin
  ConfigPath := ExpandConstant('{app}\DAL.config');

  if FileExists(ConfigPath) then
  begin
    Log('Actualizando la cadena de conexión en: ' + ConfigPath);
    Lines := TStringList.Create;
    try
      Lines.LoadFromFile(ConfigPath);

      for I := 0 to Lines.Count - 1 do
      begin
        // Usamos nuestra propia función de reemplazo en lugar de StringChange
        Lines[I] := ManualStringReplace(Lines[I], 'Instancia_502ag', SelectedSQLInstance);
      end;

      Lines.SaveToFile(ConfigPath);
      Log('Cadena de conexión actualizada a: ' + SelectedSQLInstance);
    except
      Log('Error procesando el archivo de configuración.');
    end;
    Lines.Free;
  end
  else
    Log('No se encontró el archivo de configuración: ' + ConfigPath);
end;

procedure CurStepChanged(CurStep: TSetupStep);
begin
  // Este bloque se ejecuta antes de que comience la instalación de archivos.
  if CurStep = ssInstall then
  begin
    // Esta lógica no necesita cambiar. Se decide si la BD debe crearse/restaurarse
    // independientemente de dónde se vaya a hacer.
    if IsDatabaseMissing() then
    begin
      PerformDbSetup := True;
    end
    else
    begin
      PerformDbSetup := NeedsDatabaseRestore();
    end;
  end
  // NUEVO: Este bloque se ejecuta DESPUÉS de que todos los archivos se han instalado.
  else if CurStep = ssPostInstall then
  begin
    // Aquí llamamos a la función para actualizar el archivo de configuración.
    UpdateConnectionString();
  end;
end;

procedure InitializeWizard;
begin
  UserHasBeenAsked := False;
  RestoreDatabase := False;
  PerformDbSetup := False;
  // NUEVO: Llama al procedimiento para crear la página de configuración de SQL
  CreateSqlConfigPage();
end;



function GetCreateDbScriptPath(Param: String): String;
var
  SqlScript, TempFile, FilePath: String;
begin
  TempFile := ExpandConstant('{tmp}\createtemp.sql');
  FilePath := ExpandConstant('{localappdata}\{#MyAppName}\BD_502ag.mdf');
  
  SqlScript := 'CREATE DATABASE [BD_502ag] ON PRIMARY (NAME = N''BD_502ag'', FILENAME = N''' + FilePath + ''')';
  
  if SaveStringToFile(TempFile, SqlScript, False) then
    Result := TempFile
  else
    Result := '';
end;

function IsVCRedistNeeded(): Boolean;
begin
  Result := not RegKeyExists(HKLM64, 'SOFTWARE\Microsoft\VisualStudio\14.0\VC\Runtimes\x64');
end;

function IsLocalDBInstalled(): Boolean;
begin
  Result := RegKeyExists(HKLM, 'SOFTWARE\Microsoft\Microsoft SQL Server Local DB\Installed Versions\15.0');
end;

function GetCurrentUser(Param: String): String;
begin
  if CurrentWindowsUser = '' then
    CurrentWindowsUser := GetUserNameString();
  Result := CurrentWindowsUser;
end;


// --- NUEVA FUNCIÓN PARA VERIFICAR LA BD EN CUALQUIER INSTANCIA ---
function IsDatabasePresentOnInstance(): Boolean;
var
  TempOutputFile: String;
  ResultCode: Integer;
  FileContent: AnsiString;
  Params: String;
  Query: String;
begin
  Result := False; // Por defecto, asumimos que no existe.

  // Si por alguna razón aún no se ha seleccionado una instancia, no hagas nada.
  if SelectedSQLInstance = '' then Exit;

  Log(Format('Verificando si la base de datos existe en la instancia: %s', [SelectedSQLInstance]));

  TempOutputFile := ExpandConstant('{tmp}\dbcheck.txt');
  
  // Esta consulta SQL imprime una bandera única si la base de datos existe.
  Query := 'IF DB_ID(N''BD_502ag'') IS NOT NULL PRINT N''DATABASE_EXISTS_FLAG''';

  // Construimos los parámetros para sqlcmd
  // -h-1 elimina las cabeceras del resultado para tener un archivo de salida limpio.
  Params := Format('-S "%s" -h-1 -Q "%s"', [SelectedSQLInstance, Query]);
  
  // Ejecutamos el comando y redirigimos su salida a un archivo temporal.
  // Usamos cmd.exe /C para manejar la redirección de salida (>).
  if Exec(ExpandConstant('{sys}\cmd.exe'), Format('/C ""%s\sqlcmd.exe" %s > "%s""', [ExpandConstant('{#SqlCmdPath}'), Params, TempOutputFile]), '', SW_HIDE, ewWaitUntilTerminated, ResultCode) then
  begin
    if ResultCode = 0 then
    begin
      // Si el comando se ejecutó bien, leemos el archivo de salida.
      if LoadStringFromFile(TempOutputFile, FileContent) then
      begin
        // Buscamos nuestra bandera. Si está, la base de datos existe.
        if Pos('DATABASE_EXISTS_FLAG', FileContent) > 0 then
        begin
          Log('La base de datos ''BD_502ag'' fue encontrada.');
          Result := True;
        end
        else
        begin
          Log('La base de datos ''BD_502ag'' NO fue encontrada.');
        end;
      end;
    end
    else
    begin
      Log(Format('sqlcmd falló con código de error: %d', [ResultCode]));
    end;
  end
  else
  begin
    Log('No se pudo ejecutar el comando de verificación de la base de datos.');
  end;

  // Limpiamos el archivo temporal.
  DeleteFile(TempOutputFile);
end;

// NUEVO: Esta función ahora debe verificar la BD en la instancia seleccionada.
// Por simplicidad, la dejaremos como estaba, ya que el flujo principal se controla
// con el mensaje al usuario. Una mejora sería ejecutar un `sqlcmd` aquí para verificar.
function IsDatabaseFilePresent(): Boolean;
begin
  // AHORA: Usamos la nueva lógica que consulta directamente a la instancia de SQL.
  Result := IsDatabasePresentOnInstance();
end;

function IsDatabaseMissing(): Boolean;
begin
  Result := not IsDatabaseFilePresent();
end;

function NeedsDatabaseRestore(): Boolean;
var
  Response: Integer;
begin
  if UserHasBeenAsked then
  begin
    Result := RestoreDatabase;
    Exit;
  end;
  
  if IsDatabaseMissing() then
  begin
    Result := False; // No se puede restaurar si no existe
    Exit;
  end;
  
  UserHasBeenAsked := True; 
  Response := MsgBox('Se detectó una base de datos existente. ¿Desea eliminarla y restaurarla a su estado inicial?' + #13#10#13#10 +
                     'ADVERTENCIA: Todos los datos actuales se perderán.',
                     mbConfirmation, MB_YESNO);
                      
  if Response = IDYES then
    RestoreDatabase := True
  else
    RestoreDatabase := False;
  
  Result := RestoreDatabase;
end;

function ShouldPerformDbSetup(): Boolean;
begin
  Result := PerformDbSetup;
end;

// NUEVO: Función para devolver la instancia de SQL que el usuario eligió
function GetSelectedInstance(Param: String): String;
begin
  Result := SelectedSQLInstance;
end;

// NUEVO: Función para verificar si el usuario eligió instalar LocalDB
function IsLocalDbSelected(): Boolean;
begin
  Result := (SelectedSQLInstance = '(LocalDB)\MSSQLLocalDB');
end;

[Run]
// Instala componentes base sin cambios
Filename: "{tmp}\VC_redist.x64.exe"; Parameters: "/install /quiet /norestart"; StatusMsg: "Instalando componentes de Microsoft..."; Flags: runhidden waituntilterminated; Check: IsVCRedistNeeded()
Filename: "msiexec.exe"; Parameters: "/i ""{tmp}\msodbcsql.msi"" /qn IACCEPTMSODBCSQLLICENSETERMS=YES"; StatusMsg: "Instalando controlador de conexión..."; Flags: runhidden waituntilterminated;
Filename: "msiexec.exe"; Parameters: "/i ""{tmp}\MsSqlCmdLnUtils.msi"" /qn IACCEPTMSSQLCMDLNUTILSLICENSETERMS=YES"; StatusMsg: "Instalando herramientas de base de datos..."; Flags: runhidden waituntilterminated;

// MODIFICADO: Estas secciones solo se ejecutan si el usuario seleccionó la opción LocalDB
Filename: "msiexec.exe"; Parameters: "/i ""{tmp}\SqlLocalDB.msi"" /qn IACCEPTSQLLOCALDBLICENSETERMS=YES"; StatusMsg: "Instalando motor LocalDB..."; Flags: runhidden waituntilterminated; Check: IsLocalDbSelected() and not IsLocalDBInstalled()
Filename: "{commonpf64}\Microsoft SQL Server\150\Tools\Binn\sqllocaldb.exe"; Parameters: "create MSSQLLocalDB"; Flags: runhidden waituntilterminated; Check: IsLocalDbSelected()
Filename: "{commonpf64}\Microsoft SQL Server\150\Tools\Binn\sqllocaldb.exe"; Parameters: "start MSSQLLocalDB"; Flags: runhidden waituntilterminated; Check: IsLocalDbSelected()

// Pausa para dar tiempo a que los servicios inicien, sin cambios
Filename: "cmd.exe"; Parameters: "/C timeout /T 10 /nobreak > NUL"; StatusMsg: "Iniciando servicios de base de datos..."; Flags: runhidden;

// MODIFICADO: Todos los comandos sqlcmd ahora usan la instancia seleccionada dinámicamente
Filename: "{#SqlCmdPath}\sqlcmd.exe"; Parameters: "-S ""{code:GetSelectedInstance}"" -Q ""IF EXISTS (SELECT name FROM sys.databases WHERE name = 'BD_502ag') BEGIN ALTER DATABASE BD_502ag SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE BD_502ag; END"" -E"; StatusMsg: "Eliminando base de datos antigua..."; Flags: runhidden; Check: NeedsDatabaseRestore()
Filename: "{#SqlCmdPath}\sqlcmd.exe"; Parameters: "-S ""{code:GetSelectedInstance}"" -i ""{code:GetCreateDbScriptPath}"" -E"; StatusMsg: "Creando la base de datos..."; Flags: runhidden; Check: ShouldPerformDbSetup() and IsLocalDbSelected()
Filename: "{#SqlCmdPath}\sqlcmd.exe"; Parameters: "-S ""{code:GetSelectedInstance}"" -i ""{app}\scriptCrearSoloBD_502ag.sql"" -E"; StatusMsg: "Creando la base de datos..."; Flags: runhidden; Check: ShouldPerformDbSetup() and not IsLocalDbSelected()
Filename: "{#SqlCmdPath}\sqlcmd.exe"; Parameters: "-S ""{code:GetSelectedInstance}"" -d BD_502ag -i ""{app}\scriptBD_502ag.sql"" -E"; StatusMsg: "Configurando estructura..."; Flags: runhidden; Check: ShouldPerformDbSetup()
Filename: "{#SqlCmdPath}\sqlcmd.exe"; Parameters: "-S ""{code:GetSelectedInstance}"" -d BD_502ag -Q ""IF NOT EXISTS (SELECT name FROM sys.database_principals WHERE name = N'{code:GetCurrentUser}') CREATE USER [{code:GetCurrentUser}] FOR LOGIN [{code:GetCurrentUser}]; EXEC sp_addrolemember 'db_owner', N'{code:GetCurrentUser}'"" -E"; StatusMsg: "Asignando permisos..."; Flags: runhidden; Check: ShouldPerformDbSetup()

// Lanzar la aplicación, sin cambios
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent