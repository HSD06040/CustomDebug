<div align="center">
  <img src="https://capsule-render.vercel.app/api?type=wave&color=timeGradient&height=250&section=header&text=Custom%20Debug&fontSize=70" />
</div>

<br>
<br>
<br>

<div align="center">
   <a href="https://github.com/HSD06040/CustomDebug/blob/main/README-en.md">
    <img src="https://img.shields.io/badge/English-FF3E00?style=for-the-badge" />&nbsp
  </a>
</div>

<br>
<br>
<br>

디버깅 과정을 더욱 효율적이고 시각적으로 개선하기 위해 제작된 커스텀 디버그 시스템입니다. 로그 추적과 관리를 한층 더 업그레이드해보세요!

## 얻을 수 있는 이점
1. **디버그에 스크립트 명, 디버그 줄번호, 함수 이름이 포함됩니다!**

2. **디버그에 색상을 커스터마이징 할 수 있습니다!**

3. **디버그를 로그로 남겨 버그 추적에 용이합니다!**

<br>

# 주요 기능
## 🔍 디버그 메시지 개선 및 컬러 커스터마이징

> 로그 메시지에 필수적인 컨텍스트 정보를 추가하고, 상태별 색상을 적용하여 로그 확인의 편의성을 극대화했습니다.

<br>
  
- 🎨 기본 설정 (Default Settings)

  <img width="366" height="82" alt="image" src="https://github.com/user-attachments/assets/bd529df3-5345-46ff-b9be-16832925d112" />

  현재 설정된 기본 색상 정보입니다. Resources/DebugSetting 파일에서 언제든지 변경 가능합니다.
  
<br>

- ✨ 적용 예시
  
  <img width="401" height="127" alt="image" src="https://github.com/user-attachments/assets/0cf6a33d-b029-4faa-877f-5aef0ec3b499" />
  
---

## 📁 로그 파일 저장 기능

> 콘솔에 출력된 모든 로그를 파일로 저장하여 지속적인 기록 및 분석이 가능합니다.

<br>

- ✅ 저장 여부 설정
  
  <img width="366" height="134" alt="image" src="https://github.com/user-attachments/assets/6d788880-9bd0-432f-ac24-7ef91b27d763" />

  로그 파일 저장 기능의 활성화/비활성화 여부는 DebugSetting 파일에서 설정할 수 있습니다.

<br>

- 📄 저장된 로그 파일

  <img width="536" height="71" alt="image" src="https://github.com/user-attachments/assets/fdc4f6d3-d32f-4208-ab39-960bbedc55c7" />

  저장된 로그 파일의 모습입니다.
  
<br>

- 💾 저장 경로 수정
  
  로그 파일의 저장 경로는 Debug.cs 파일 내의 Init() 스크립트에서 수정할 수 있습니다.
  
  ```cs
  static void Init()
  {
      debugSetting = Resources.Load<DebugSetting>("DebugSetting");

      // 기본 저장 경로: Application.streamingAssetsPath 아래에 설정된 파일 이름으로 저장
      saveHandler = new DebugSaveHandler($"{Application.streamingAssetsPath}/{debugSetting.fileName}", debugSetting.isFileSave);
  }
  ```

  ## ⚙️ 사용법

  예) 디버그
  ```cs
  private void Start()
  {
      Debug.Log("Log");
      Debug.LogWarning("Log Warning");
      Debug.LogError("Log Error");
  }
  ```

  예) 저장
  > 호출하지 않을 시 저장되지 않습니다.
  ```cs
  private void Save() => Debug.Save();
  ```

  
