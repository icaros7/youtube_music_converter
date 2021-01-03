# Youtube Music Converter
[VideoLibrary](https://github.com/omansak/libvideo)를 활용한 Youtube 음원 변환기 입니다.  
[FFmpeg.Shared](https://www.nuget.org/packages/FFmpeg.Shared)를 통하여 최종적으로 Youtube 영상을 [MP3](https://ko.wikipedia.org/wiki/MP3) 확장자로 저장 합니다.

It's a Youtube music converter that using [VideoLibrary](https://github.com/omansak/libvideo).  
Finaly, You can save Youtube video to [MP3](https://en.wikipedia.org/wiki/MP3) extension via [FFmpeg.Shared](https://www.nuget.org/packages/FFmpeg.Shared)

---

## 지원 환경 / Support Enviroment
### 요구 사항
- [.Net Core 3.1 이상 Runtime](https://dotnet.microsoft.com/download/dotnet-core)
### Requirements
- [.Net Core more than 3.1 Runtime](https://dotnet.microsoft.com/download/dotnet-core)

### 지원 언어 / Support Language
- English
- 한국어 (Korean)

## 사용법 (한국어 / Korean)
### CUI
1. 큐를 위한 빈 텍스트 파일을 만드세요.
2. 해당 파일 내에 VideoLibraray가 지원하는 형식의 주소 (예: Youtube)를 개행을 통해 구분하여 작성 합니다.
3. 해당 txt 파일을 실행 파일에 드래그앤드롭 하거나 아래 명령어 예시를 통하여 실행합니다.
<pre>
<code>
Linux :
$ dotnet Youtube_Music_Converter.dll 사용자_큐.txt


Windows :
Youtube_Music_Converter.exe 사용자_큐.txt
</code>
</pre>
4. 사용자 큐 텍스트 파일과 이름이 같은 폴더 내에 다운로드가 시작 됩니다.

### GUI
![스크린샷](https://github.com/icaros7/youtube_music_converter/blob/gui_win_form/Image/preview_Korean.png?raw=true)
- URL을 입력하여 직접 추가
- 클립보드의 내용을 붙여넣기 버튼을 통해 추가
- 텍스트 파일 불러오기
- 텍스트 파일 드레그앤드롭 으로 열기

---
## How to use (English)
#### CUI
1. Make empty text file to use queue
2. In the file, write the address in the format supported by VideoLibraray (eg Youtube) separated by a newline.
3. Drag and drop the txt file to the executable file or execute it through the command example below.
<pre>
<code>
Linux :
$ dotnet Youtube_Music_Converter.dll YOUR_QUEUE.txt


Windows :
Youtube_Music_Converter.exe YOUR_QUEUE.txt
</code>
</pre>
4. The download starts within a directory with the same name as the your queue text file.

#### ~GUI~
~Coming soon~


---
## 오픈소스 라이센스 / OPENSOURCE LICENSE
- VideoLibarary - [홈페이지/Homepage](https://github.com/omansak/libvideo), [라이센스/License](https://github.com/omansak/libvideo/blob/master/LICENSE)
- Apache log4net™ - [홈페이지/Homepage](https://logging.apache.org/log4net/index.html), [라이센스/License](http://www.apache.org/licenses/LICENSE-2.0.html)
- FFmpeg.Shared - [홈페이지/Homepage](https://www.nuget.org/packages/FFmpeg.Shared), [라이센스/License](https://www.gnu.org/licenses/gpl-3.0.txt)