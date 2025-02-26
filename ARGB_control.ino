#include <FastLED.h>

#define DATA_PIN 5
#define LED_TYPE WS2812
#define COLOR_ORDER GRB
#define NUM_LEDS 30

CRGB leds[NUM_LEDS];

#define BRIGHTNESS 10
#define INTERVAL 50 // 更新間隔時間

unsigned long previousTime = 0;
static uint8_t hue = 0; // 色調變數
int index = 0;

// 儲存 LED 模式與顏色
byte ledMode = 4;
byte colorR = 180, colorG = 255, colorB = 255;

void setup() {
  Serial.begin(9600);
  FastLED.addLeds<LED_TYPE, DATA_PIN, COLOR_ORDER>(leds, NUM_LEDS).setCorrection(TypicalLEDStrip);
  FastLED.setBrightness(BRIGHTNESS);
}

void loop() {
  // 若有資料進來
  if (Serial.available()) {
    // 檢查第一個字元：
    int peekVal = Serial.peek(); // 取得不移除緩衝區的第一個字元
    // 如果第一個字元是字母 (例如 'G' 開頭代表 GET_MODE)
    if (isAlpha(peekVal)) {
      String command = Serial.readStringUntil('\n'); // 處理文字指令
      if (command == "GET_MODE") {
        Serial.print("MODE:");
        Serial.println(ledMode); // 回傳當前模式
      }
    }
    // 否則如果資料量足夠 4 byte，就處理二進位指令
    else if (Serial.available() >= 4) {
      ledMode = Serial.read(); // 接收模式
      int receivedR = Serial.read();
      int receivedG = Serial.read();
      int receivedB = Serial.read();

      // 限制輸入範圍 0-100
      receivedR = constrain(receivedR, 0, 100);
      receivedG = constrain(receivedG, 0, 100);
      receivedB = constrain(receivedB, 0, 100);

      // 映射到實際輸出範圍（紅:0-180，綠/藍:0-255）
      colorR = map(receivedR, 0, 100, 0, 180);
      colorG = map(receivedG, 0, 100, 0, 255);
      colorB = map(receivedB, 0, 100, 0, 255);

      LedOff();
      index = 0; // 重新初始化 index

      // Log: 顯示接收到的數據
      Serial.print("Received Mode: ");
      Serial.print(ledMode);
      Serial.print(" | Color: ");
      Serial.print(colorR);
      Serial.print(", ");
      Serial.print(colorG);
      Serial.print(", ");
      Serial.print(colorB);
      Serial.print("\n");
    }
  }

  // LED 更新 (每 INTERVAL ms 執行一次)
  unsigned long currentTime = millis();
  if (currentTime - previousTime >= INTERVAL) {
    previousTime = currentTime;
    switch (ledMode) {
      case 0: // 關閉 (LedOff)
        LedOff();
        break;
      case 1: // 彩虹模式
        Rainbow();
        break;
      case 2: // 跑馬燈
        Running(index, colorR, colorG, colorB);
        index = (index + 1) % NUM_LEDS;
        break;
      case 3: // 隨機閃爍
        Random(colorR, colorG, colorB);
        break;
      case 4:
        StaticColor(colorR, colorG, colorB);
        break;
      case 5:
        Breathing(colorR, colorG, colorB);
        break;
      default:
        break;
    }
    FastLED.show();
  }
}

void LedOff(){
  for (int i = 0; i < NUM_LEDS; i++) {
    leds[i] = CRGB::Black;
  }
}

// 彩虹模式
void Rainbow() {
  for (int i = 0; i < NUM_LEDS; i++) {
    leds[i] = CHSV(hue - (i * 5), 255, 255);
  }
  hue += 5;
}

// 跑馬燈模式
void Running(int index, int r, int g, int b) {
  leds[index] = CRGB(r, g, b);
  if (index > 0) leds[index - 1] = CRGB::Black;
  else leds[NUM_LEDS - 1] = CRGB::Black;
}

// 隨機閃爍模式（同時閃爍 3 到 6 個 LED）
void Random(int r, int g, int b) {
  static unsigned long lastChange = 0;
  static int activeLeds[6] = {-1, -1, -1, -1, -1, -1}; // 最多 6 顆燈
  static int ledCount = 3;  // 目前閃爍的 LED 數量

  if (millis() - lastChange > 500) {
    // 清除舊的 LED 狀態
    for (int i = 0; i < ledCount; i++) {
      if (activeLeds[i] != -1) {
        leds[activeLeds[i]] = CRGB::Black;
      }
    }

    // 隨機決定新的閃爍數量（3 到 6 顆）
    ledCount = random(2, 7);

    // 重新選擇新的 LED 位置
    for (int i = 0; i < ledCount; i++) {
      activeLeds[i] = random(NUM_LEDS);
      leds[activeLeds[i]] = CRGB(r, g, b);
    }

    lastChange = millis();
  }
}

// 1. 靜態顏色模式
void StaticColor(int r, int g, int b) {
  for (int i = 0; i < NUM_LEDS; i++) {
    leds[i] = CRGB(r, g, b);
  }
}

void Breathing(int r, int g, int b) {
  static float t = 0;  // 時間變數
  t += 0.1;  // 控制變化速度，數值越小越慢

  // 使用 sin() 讓亮度變化更加平滑
  float brightness = (sin(t) + 1.0) / 2.0 * 255; 

  for (int i = 0; i < NUM_LEDS; i++) {
    leds[i] = CRGB(r * brightness / 255, g * brightness / 255, b * brightness / 255);
  }

  FastLED.show();
  delay(30);  // 控制更新速度
}

