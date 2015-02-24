; скрипт инсталлятора программы Калькулятор рецептур
; версия 2008-11-12

; константы
!define PRODUCT_NAME "Калькулятор рецептур"
!define PRODUCT_VERSION "0.10"
!define PRODUCT_PUBLISHER "SeekerSoft"
!define PRODUCT_WEB_SITE "http://ptz.ath.cx"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\Recept2.exe"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"
!define PRODUCT_DISTR_NAME "recept2setup-${PRODUCT_VERSION}.exe"
!define PRODUCT_EXE_NAME "recept2.exe"

!define ICONS_GROUP "${PRODUCT_NAME}" #папка ярлыка в меню Пуск

!define EXT_PANDOC "pandoc-1.2.1-setup.exe"

BrandingText "  (c) 2008   SeekerSoft  "

;--------------------------------
; подключаемые библиотеки

  !include "MUI.nsh"
  !include "WordFunc.nsh"
      	!insertmacro VersionCompare
  !include "StrFunc.nsh"
 	!insertmacro FUNCTION_STRING_StrLoc
	!insertmacro FUNCTION_STRING_StrTok
  !include "LogicLib.nsh"
  !include "FileFunc.nsh"
  !include "registerExtension.nsh"

;--------------------------------
; глобальные переменные

Var MUI_TEMP
Var STARTMENU_FOLDER
Var ProjectRegKey

Var WinVer
Var NTSPVer
Var IsCorrectWin
Var WinLang

Var FWVer
Var IsCorrectFW

Var IEVer
Var IsCorrectIE

Var MSInstVer
Var IsCorrectMSInst

Var PandocVer
Var IsCorrectPandoc

;--------------------------------
;Общие настройки

  XPStyle on

  Name "${PRODUCT_NAME}"

  OutFile "${PRODUCT_DISTR_NAME}"
  Caption "${PRODUCT_NAME} ${PRODUCT_VERSION}"
 
  ;Default installation folder
  InstallDir "$PROGRAMFILES\SeekerSoft\Recept2"
  
  ;Get installation folder from registry if available
  InstallDirRegKey HKCU $ProjectRegKey ""
   
  ; запрашиваем права админа
  RequestExecutionLevel admin  

;--------------------------------
;Interface Settings
  !define MUI_ABORTWARNING

;--------------------------------
;Подключаемые страницы

  ; установка
  !insertmacro MUI_PAGE_LICENSE "License.txt"
  !insertmacro MUI_PAGE_WELCOME
  !insertmacro MUI_PAGE_COMPONENTS
  !insertmacro MUI_PAGE_DIRECTORY


  ;Start Menu Folder Page Configuration
  !define MUI_STARTMENUPAGE_REGISTRY_ROOT "HKCU" 
  !define MUI_STARTMENUPAGE_REGISTRY_KEY $ProjectregKey
  !define MUI_STARTMENUPAGE_REGISTRY_VALUENAME "Start Menu Folder"
 
  !insertmacro MUI_PAGE_STARTMENU Application $STARTMENU_FOLDER

  !insertmacro MUI_PAGE_INSTFILES

  ; удаление
  !insertmacro MUI_UNPAGE_WELCOME
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES

  ; Finish page
  !define MUI_FINISHPAGE_RUN "$INSTDIR\${PRODUCT_EXE_NAME}"  
  !insertmacro MUI_PAGE_FINISH
  
;--------------------------------
;Languages
 
  !insertmacro MUI_LANGUAGE "Russian"

;--------------------------------
;Installer Sections

Section "${PRODUCT_NAME} (обязательно)" SecMain

  SectionIn RO    ; required

  SetShellVarContext all
  SetOutPath "$INSTDIR"
  File ..\bin\debug\${PRODUCT_EXE_NAME} 
  File ..\bin\debug\ExpandableGridView.dll 
  File /r ..\ExtLibs\*.dll 
  File ..\version.txt

  ;Store installation folder
  WriteRegStr HKCU $ProjectRegKey "" ""
  WriteRegStr HKCU $ProjectRegKey "Install Location" $INSTDIR

  ; регистрация расширения файла  
  ${registerExtension} "$INSTDIR\${PRODUCT_EXE_NAME}" ".rcp2" "Книга рецептур"

  ;Create uninstaller
  WriteUninstaller "$INSTDIR\Uninstall.exe"

  !insertmacro MUI_STARTMENU_WRITE_BEGIN Application
    
    ;Create shortcuts
    CreateDirectory "$SMPROGRAMS\$STARTMENU_FOLDER"
    CreateShortCut "$SMPROGRAMS\$STARTMENU_FOLDER\${PRODUCT_NAME}.lnk" "$INSTDIR\${PRODUCT_EXE_NAME}"
    CreateShortCut "$SMPROGRAMS\$STARTMENU_FOLDER\Uninstall.lnk" "$INSTDIR\Uninstall.exe"
    ;SetShellVarContext all
    CreateShortCut "$DESKTOP\${PRODUCT_NAME}.lnk" "$INSTDIR\${PRODUCT_EXE_NAME}"

   ; добавляем в установку/удаление
   WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "DisplayName" "${PRODUCT_NAME}"
   WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "UninstallString" "$INSTDIR\Uninstall.exe"
   WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "InstallLocation" "$INSTDIR"
   WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "DisplayIcon" "$INSTDIR\${PRODUCT_EXE_NAME}"
   WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "Publisher" "${PRODUCT_PUBLISHER}"
   WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "HelpLink" "${PRODUCT_WEB_SITE}"
   WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "URLUpdateInfo" "${PRODUCT_WEB_SITE}"
   WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "URLInfoAbout" "${PRODUCT_WEB_SITE}"
   WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "NoModify" 1
   WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "NoRepair" 1
    
  !insertmacro MUI_STARTMENU_WRITE_END

SectionEnd

;-------------------------------------------
; секция установки бд и шаблонов

Section "База данных" SecTemplates
  SetOutPath "$APPDATA\SeekerSoft\Recept2\"
  SetOverwrite off
  File components.mdb
  File components.sqlite

  WriteRegStr HKLM $ProjectRegKey "DBFile" "$APPDATA\SeekerSoft\Recept2\components.sqlite"
SectionEnd

;-------------------------------------------
; секция установки библиотеки Pandoc

Section "Библиотека Pandoc" SecPandoc
; TODO: добавить установку/обновление

SectionEnd

;--------------------------------------------
; описание секций
LangString DESC_SecMain ${LANG_RUSSIAN} "Программа расчета рабочих рецептур"
LangString DESC_SecTemplates ${LANG_RUSSIAN} "База данных рецептур"
  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
    !insertmacro MUI_DESCRIPTION_TEXT ${SecMain} $(DESC_SecMain)
    !insertmacro MUI_DESCRIPTION_TEXT ${SecTemplates} $(DESC_SecTemplates)
  !insertmacro MUI_FUNCTION_DESCRIPTION_END

;--------------------------------
;Uninstaller Section

Section "Uninstall"
  SetShellVarContext all                       
  RMDir /r /REBOOTOK "$INSTDIR"
  Delete "$DESKTOP\${PRODUCT_NAME}.lnk"
  RMDir /r "$APPDATA\SeekerSoft\Recept2"

  ; удаляем ассоциации
  ${unregisterExtension} ".rcp2" "Книга рецептур"

  !insertmacro MUI_STARTMENU_GETFOLDER Application $MUI_TEMP

;Delete empty start menu parent diretories
  StrCpy $MUI_TEMP "$SMPROGRAMS\$MUI_TEMP"
  RMDir /r $MUI_TEMP
 
  
  /*EnumRegValue $1 HKCU $ProjectRegKey $0
  IfErrors done
  DeleteRegValue HKCU $ProjectRegKey $1
  done:*/

  DeleteRegKey HKCU $ProjectRegKey

  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"

  sleep 700 
SectionEnd

; ---------------------------------------------------
; Дополнительные функции

Function un.onInit
     StrCpy $ProjectRegKey "Software\SeekerSoft\Recept2"	
FunctionEnd

Function .onInit
   StrCpy $ProjectRegKey "Software\SeekerSoft\Recept2"
   Call CheckWinVersion
   Call CheckFWVersion
   Call CheckIEVersion
   Call CheckWIVersion
/*   MessageBox MB_OK "OS version: $WinVer $\nSP version (for NT x.x): $NTSPVer $\nIs correct OS: $IsCorrectWin \
		 $\nSystem language: $WinLang $\nWindows Installer Version: $MSInstVer  $\nIs correct Win Installer: $IsCorrectMSInst \
		 $\nFrameWork: $FWVer $\nIs Correct FW: $IsCorrectFW \
		 $\nIE version: $IEVer $\nIs correct IE: $IsCorrectIE"
*/ 
   Call PrepareInstall
FunctionEnd

Function .OnInstSuccess
	Call DelFromAutorun
	WriteRegStr HKCU "Software\Microsoft\Internet Explorer\PageSetup" "footer" ""
	WriteRegStr HKCU "Software\Microsoft\Internet Explorer\PageSetup" "header" ""
FunctionEnd
Function .OnInstFailed
	Call DelFromAutorun
FunctionEnd

Function PrepareInstall
Call AddToAutorun
#Проверка винды
    ${If} $IsCorrectWin == 0
	MessageBox MB_OK "Данная программа не предназначена для работы $\n с операционной системой Windows $WinVer"
	Call DelFromAutorun
	Abort
   ${EndIf}

#проверка FW
   ${If} $IsCorrectFW == 0
	
   #Ветка true (т.е. установить FW)
        #проверка IE
	${If} $IsCorrectIE == 0
		${If} $WinVer == '98'
			MessageBox  MB_YESNO "Для установки необходим Internet Explorer 5.01 или более поздней версии \
				$\nУстановить Internet Explorer 5.5 ? $\nНажмите 'Нет' если вы хотите прервать установку" IDYES trueIE2 IDNO falseIE2
			trueIE2:
				${If} $WinLang == "ru"
					FileOpen $0 "$EXEDIR\Utils\win98\ie55rus\ie5setup.exe" r
					IfErrors fileIEError
					FileClose $0
					ExecWait '"$EXEDIR\Utils\win98\ie55rus\ie5setup.exe"' $0
					Goto exitIE
				${Else}
					FileOpen $0 "$EXEDIR\Utils\win98\ie55eng\ie5setup.exe" r
					IfErrors fileIEError
					FileClose $0
					ExecWait '"$EXEDIR\Utils\win98\ie55eng\ie5setup.exe"' $0
					Goto exitIE
				${EndIf}
			falseIE2: 
				Call DelFromAutorun
				Abort
		${Else}
			${If} $IEVer == ""
				MessageBox MB_OK "Для установки необходим Internet Explorer 5.01 или более поздней версии $\n"
			${Else}
				MessageBox MB_OK "Обнаружен Internet Explorer $IEVer \
					$\nДля установки необходим Internet Explorer 5.01 или более поздней версии $\n"		
			${EndIF}
			Call DelFromAutorun
			Abort
		${EndIf}
		fileIEError:
			MessageBox MB_OK "Файл '$EXEDIR\Utils\win98\ie55rus\ie5setup.exe' не найден.$\n \
				Дальнейшая установка невозможна"
			Call DelFromAutorun
			Abort
		exitIE:
		sleep 700
	${EndIf}
	
	#проверка MSI
	${If} $IsCorrectMSInst == 0
		${If} $WinVer == '98'
			MessageBox MB_YESNO "Для установки необходим установщик Windows Installer 2 или более поздней версии \
				$\nУстановить Windows Installer 2.0 ? $\nНажмите 'Нет' если вы хотите прервать установку" IDYES trueMSI2 IDNO falseMSI2
                        trueMSI2:
				FileOpen $0 "$EXEDIR\Utils\win98\instmsi\instmsia.exe" r
				IfErrors fileMSI1Error
				FileClose $0
				ExecWait '"$EXEDIR\Utils\win98\instmsi\instmsia.exe"' $0
				Goto exitMSI
			falseMSI2: 
				Call DelFromAutorun
				Abort
		${Else}
			${If} $MSInstVer == ""
				MessageBox MB_YESNO "Для установки необходим установщик Windows Installer 3 или более поздней версии \
					$\nУстановить Windows Installer 3.1 ? $\nНажмите 'Нет' если вы хотите прервать установку" IDYES trueMSI0 IDNO falseMSI0
	                        trueMSI0:
					FileOpen $0 "$EXEDIR\Utils\WindowsInstaller-KB893803-v2-x86.exe" r
					IfErrors fileMSI2Error
					FileClose $0
					ExecWait '"$EXEDIR\Utils\WindowsInstaller-KB893803-v2-x86.exe"' $0
					Goto exitMSI
				falseMSI0: 
					Call DelFromAutorun
					Abort
			${Else}
				MessageBox MB_YESNO  "Обнаружен Microsoft Installer $MSInstVer \
					$\nДля установки необходим установщик Windows Installer 3 или более поздней версии \
					$\n$\nУстановить Windows Installer 3.1 ? $\nНажмите 'Нет' если вы хотите прервать установку" IDYES trueMSI1 IDNO falseMSI1
	                        trueMSI1:
					FileOpen $0 "$EXEDIR\Utils\WindowsInstaller-KB893803-v2-x86.exe" r
					IfErrors fileMSI2Error
					FileClose $0
					ExecWait '"$EXEDIR\Utils\WindowsInstaller-KB893803-v2-x86.exe"' $0
					Goto exitMSI
				falseMSI1: 
					Call DelFromAutorun
					Abort
			${EndIf}
		${EndIf}
		fileMSI1Error:
			MessageBox MB_OK "Файл '$EXEDIR\Utils\win98\instmsi\instmsia.exe' не найден.$\n \
				Дальнейшая установка невозможна"
			Call DelFromAutorun
			Abort
		fileMSI2Error:
			MessageBox MB_OK "Файл '$EXEDIR\Utils\WindowsInstaller-KB893803-v2-x86.exe' не найден.$\n \
				Дальнейшая установка невозможна"
			Call DelFromAutorun
			Abort
		exitMSI:
		sleep 700
	${EndIf}

     
	${If} $FWVer != ""
	        MessageBox MB_YESNO "Обнаружен .NETFrameWork $FWVer $\nДля установки необходим .NET FrameWork 2.0 или более поздней версии \
			$\nУстановить .NET FrameWork 2.0 ? $\nНажмите 'Нет' если вы хотите прервать установку" IDNO falseFW0
		Goto exitFWver
		falseFW0: 
			Call DelFromAutorun
			Abort
	${Else}
		MessageBox MB_YESNO "Для установки необходим .NET FrameWork 2.0 или более поздней версии \
			$\nУстановить .NET FrameWork 2.0 ? $\nНажмите 'Нет' если вы хотите прервать установку" IDNO falseFW1
		Goto exitFWver
		falseFW1: 
			Call DelFromAutorun
			Abort
	${EndIf}
        exitFWver:
	
	#проверка языка
	${If} $WinLang == "ru"
		FileOpen $0 "$EXEDIR\Utils\dotNetFW\RUS\dotnetfx.exe" r
		IfErrors fileFWError
		FileClose $0
		ExecWait '"$EXEDIR\Utils\dotNetFW\RUS\dotnetfx.exe"' $0
		Goto exitFW
	${Else}
		FileOpen $0 "$EXEDIR\Utils\dotNetFW\ENG\dotnetfx.exe" r
		IfErrors fileFWError
		FileClose $0
		ExecWait '"$EXEDIR\Utils\dotNetFW\ENG\dotnetfx.exe"' $0
		Goto exitFW
	${EndIf}
	fileFWError:
		MessageBox MB_OK "Файл '$EXEDIR\Utils\dotNetFW\RUS\dotnetfx.exe' не найден.$\n \
			Дальнейшая установка невозможна"
		Call DelFromAutorun
		Abort
	exitFW:
	sleep 700 
   ${EndIf}
FunctionEnd

Function CheckWIVersion
	FileOpen $0 "$SYSDIR\msi.dll" r
	IfErrors NotFoundVer

	GetDllVersion "$SYSDIR\msi.dll" $R0 $R1
	IntOp $R2 $R0 / 0x00010000
	IntOp $R3 $R0 & 0x0000FFFF
	IntOp $R4 $R1 / 0x00010000
	IntOp $R5 $R1 & 0x0000FFFF
	StrCpy $MSInstVer "$R2.$R3.$R4.$R5"

	${If} $WinVer == "98"
		${VersionCompare} $R2 "2" $1
	${Else}
		${VersionCompare} $R2 "3" $1
	${EndIf}
	${If} $1 == 2
		Goto NotFoundVer
	${Else}	
		StrCpy $IsCorrectMSInst 1
		Goto exit
	${EndIf}

	NotFoundVer:
	 	StrCpy $IsCorrectMSInst 0
	exit:
FunctionEnd

Function CheckIEVersion
       /*	ReadRegStr $0 HKLM "Software\Microsoft\Internet Explorer" Version
	IfErrors NotFoundVer

        ${VersionCompare} $0 "5.0.2919.6307" $1
	${If} $1 == 2    # current version of IE is older than "5.0.2919.6307"
		Goto NotFoundVer
	${Else}
		StrCpy $IsCorrectIE 1
		StrCpy $IEVer $0
		Goto exit
	${EndIf}
	NotFoundVer: 
		StrCpy $IsCorrectIE 0
	exit: */
	Call GetIEVersion
	pop $R0   
	StrCpy $IEVer $R0
	${VersionCompare} $R0 "5.0.2919.6307" $1
	${If} $1 == 2    # current version of IE is older than "5.0.2919.6307"
		Goto NotFoundVer
	${Else}
		StrCpy $IsCorrectIE 1
		Goto exit
	${EndIf}
	NotFoundVer: 
		StrCpy $IsCorrectIE 0
	exit: 
FunctionEnd


; проверка версии винды
; изменяет переменные WinVer и IsCorrectWin
function CheckWinVersion
        #получаем язык системы
	ReadRegStr $0 HKLM "SYSTEM\CurrentControlSet\Control\Nls\Language" InstallLanguage
	${If} $0 == 0419
		StrCpy $WinLang ru
	${Else}
		ReadRegStr $0 HKU ".DEFAULT\Control Panel\International" Locale
		${If} $0 == "00000419"
			StrCpy $WinLang ru
		${Else}
			StrCpy $WinLang eng
	        ${EndIf}
        ${EndIf}

       	Call GetWindowsVersion
	pop $WinVer
        
        #$0 - первые два символа версии винды (используем для NT систем)
	#$1 - вхождение слова NT в версию винды. еcли нет вхожлдения, то $0=""
	#$2 - версия NT

	StrCpy $0 $WinVer 2 0
	${StrLoc} $1 $WinVer NT >
	${If} $1 == 0 
		${StrTok} $2 $WinVer " ." "1" "0"
	${EndIf}

        #Если Win 95
	${If} $WinVer == "95"
		StrCpy "$isCorrectWin" 0
		Goto exit
	${EndIf}
	
	#Если NT версии отличной от 4
	${If} $0 == "NT"
	${AndIf} $2 != "4"
	    	StrCpy "$isCorrectWin" 0
		Goto exit
	${EndIf}

	#Если NT версии 4, то проверяем версию сервис пака (должна быть >6)
 	${If} $0 == "NT" 
	${AndIf} $2 == "4"
    	    Call GetNTSPVer
		pop $NTSPVer
		${VersionCompare} $NTSPVer "6.0a" $3
		${If} $3 == 2
			StrCpy "$isCorrectWin" 0
	    		Goto exit
		${EndIf} 

/*		${If} $NTSPVer < 6
			StrCpy "$isCorrectWin" 0
	    		Goto exit
		${EndIf} 
*/
	${EndIf} 
  
        StrCpy "$isCorrectWin" 1
	exit:
FunctionEnd

; Проверка версии FrameWork'а
; изменяет переменные FWVer и IsCorrectFW
function CheckFWVersion
  Call GetDotNETVersion
  Pop $0
  ${If} $0 == "not found"
    StrCpy "$IsCorrectFW" "0"
    Goto exit
  ${EndIf}

  StrCpy $FWVer $0

  StrCpy $0 $0 "" 1 # skip "v"

# Syntax: ${VersionCompare} "[Version1]" "[Version2]" $var
# "[Version1]"        ; First version
# "[Version2]"        ; Second version
# $var                ; Result:
#                     ;    $var=0  Versions are equal
#                     ;    $var=1  Version1 is newer
#                     ;    $var=2  Version2 is newer 
  ${VersionCompare} $0 "2" $1
	
  ${If} $1 == 2
	StrCpy "$IsCorrectFW" "0"
  ${else}
	StrCpy "$IsCorrectFW" "1"
  ${EndIf}
  exit:
FunctionEnd

;GetNTSPVer
;
;Получение версии сервис пака для NT систем
function GetNTSPVer
   Push $R0
   Push $R1
   StrCpy $R0 0
   ClearErrors
   ReadRegStr $R0 HKLM "SOFTWARE\Microsoft\Windows NT\CurrentVersion" CSDVersion
   IfErrors exit
   StrCpy $R1 $R0 4 13
   StrCpy $R0 $R1
exit:
   Pop $R1
   Exch $R0
FunctionEnd

; GetWindowsVersion
 ;
 ; Based on Yazno's function, http://yazno.tripod.com/powerpimpit/
 ; Updated by Joost Verburg
 ;
 ; Returns on top of stack
 ;
 ; Windows Version (95, 98, ME, NT x.x, 2000, XP, 2003)
 ; or
 ; '' (Unknown Windows Version)
 ;
 ; Usage:
 ;   Call GetWindowsVersion
 ;   Pop $R0
 ;   ; at this point $R0 is "NT 4.0" or whatnot
 
 Function GetWindowsVersion
 
   Push $R0
   Push $R1
 
   ClearErrors
 
   ReadRegStr $R0 HKLM \
   "SOFTWARE\Microsoft\Windows NT\CurrentVersion" CurrentVersion

   IfErrors 0 lbl_winnt
   
   ; we are not NT
   ReadRegStr $R0 HKLM \
   "SOFTWARE\Microsoft\Windows\CurrentVersion" VersionNumber
 
   StrCpy $R1 $R0 1
   StrCmp $R1 '4' 0 lbl_error
 
   StrCpy $R1 $R0 3
 
   StrCmp $R1 '4.0' lbl_win32_95
   StrCmp $R1 '4.9' lbl_win32_ME lbl_win32_98
 
   lbl_win32_95:
     StrCpy $R0 '95'
   Goto lbl_done
 
   lbl_win32_98:
     StrCpy $R0 '98'
   Goto lbl_done
 
   lbl_win32_ME:
     StrCpy $R0 'ME'
   Goto lbl_done
 
   lbl_winnt:
 
   StrCpy $R1 $R0 1
 
   StrCmp $R1 '3' lbl_winnt_x
   StrCmp $R1 '4' lbl_winnt_x
 
   StrCpy $R1 $R0 3
 
   StrCmp $R1 '5.0' lbl_winnt_2000
   StrCmp $R1 '5.1' lbl_winnt_XP
   StrCmp $R1 '5.2' lbl_winnt_2003 lbl_error
 
   lbl_winnt_x:
     StrCpy $R0 "NT $R0" 6
   Goto lbl_done
 
   lbl_winnt_2000:
     Strcpy $R0 '2000'
   Goto lbl_done
 
   lbl_winnt_XP:
     Strcpy $R0 'XP'
   Goto lbl_done
 
   lbl_winnt_2003:
     Strcpy $R0 '2003'
   Goto lbl_done
 
   lbl_error:
     Strcpy $R0 ''
   lbl_done:
 
   Pop $R1
   Exch $R0
 
 FunctionEnd

; GetIEVersion
 ;
 ; Based on Yazno's function, http://yazno.tripod.com/powerpimpit/
 ; Returns on top of stack
 ; 1,2,3,4.x.x.x,5.x.x.x,6.x.x.x (Installed IE Version)
 ; or
 ; '' (IE is not installed)
 ;
 ; Usage:
 ;   Call GetIEVersion
 ;   Pop $R0
 ;   ; at this point $R0 is "5" or whatnot

 Function GetIEVersion
 Push $R0
   ClearErrors
   ReadRegStr $R0 HKLM "Software\Microsoft\Internet Explorer" "Version"
   IfErrors lbl_123 lbl_456

   lbl_456: ; ie 4+
     Strcpy $R0 $R0 
   Goto lbl_done

   lbl_123: ; older ie version
     ClearErrors
     ReadRegStr $R0 HKLM "Software\Microsoft\Internet Explorer" "IVer"
     IfErrors lbl_error

       StrCpy $R0 $R0 3
       StrCmp $R0 '100' lbl_ie1
       StrCmp $R0 '101' lbl_ie2
       StrCmp $R0 '102' lbl_ie2

       StrCpy $R0 '3' ; default to ie3 if not 100, 101, or 102.
       Goto lbl_done
         lbl_ie1:
           StrCpy $R0 '1'
         Goto lbl_done
         lbl_ie2:
           StrCpy $R0 '2'
         Goto lbl_done
     lbl_error:
       StrCpy $R0 ''
   lbl_done:
   Exch $R0
 FunctionEnd


Function GetDotNETVersion
  Push $0
  Push $1
 
  System::Call "mscoree::GetCORVersion(w .r0, i ${NSIS_MAX_STRLEN}, *i) i .r1"
  StrCmp $1 "error" 0 +2
    StrCpy $0 "not found"
 
  Pop $1
  Exch $0
FunctionEnd

Function AddToAutorun
	WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\RunOnce" "Recept2_install" "$EXEDIR\${PRODUCT_DISTR_NAME}"
FunctionEnd
Function DelFromAutorun
	 DeleteRegValue HKCU "Software\Microsoft\Windows\CurrentVersion\RunOnce" "Recept2_install"
FunctionEnd