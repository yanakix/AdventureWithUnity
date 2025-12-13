# 2D Metroidvania Demo

> Unity 2D｜横版动作 / 类银河城

## 项目简介

该项目是一个基于 **Unity 引擎** 开发的 2D 横版动作游戏项目，目标是系统性学习并实践 Unity 2D游戏开发流程。

项目在 Udemy 课程的基础上进行 **二次设计与扩展**，并非简单复刻。原课程最终实现了一个完整的游戏片段，后续我计划将其做成一个流程完整、各方面完备的成熟的游戏。目前项目仍在持续开发中。

课程链接：[Alex老师的课程](https://www.udemy.com/course/2d-rpg-alexdev/)

## 项目目标

* 掌握 Unity 2D 开发的完整流程
* 熟悉角色控制、战斗、技能等核心系统的设计与实现
* 培养工程化思维，为今后的开发积累经验

## 技术栈

* **引擎**：Unity（2D）
* **语言**：C#
* **核心方向**：客户端逻辑、角色系统、战斗系统
* **工具**：Git

## 已实现系统

### 角色移动系统

* 基于状态划分的角色控制逻辑
  * 基础移动 / 奔跑
  * 冲刺（Dash）
  * 贴墙滑行（Wall Slide）
  * 滑铲（Sliding Tackle）

**设计要点：**

* 使用清晰的状态切换条件，避免复杂 if-else 堆叠

---

### 攻击系统

* 攻击系统基于状态机实现
* 实现基础连击系统（最多三段）与弹反机制
* 已经实现配套的数值系统及对应的UI
* 通过动画的Event来触发攻击判定，并转到数值系统进行对应计算和UI显示

---

### 技能系统

* 初步完成技能系统框架设计
* 支持不同技能类型与独立逻辑

#### 技能分类

* 两个基类Skill和SkillController搭建起整个技能框架
* 通过SkillManager类管理所有技能，并为后续的技能树系统铺垫
* 已实现投掷类技能、水晶技能与终极技能
---

## 项目结构

```text
AdventureWithUnity/
├── Assets/
│   ├── Animation/         # 存放动画
│   ├── Graphics/          # 存放图形素材
│   ├── Materials/         # 存放材质
│   ├── Prefabs/           # 存放预制体
│   ├── Scenes/
│   ├── Scripts/
│   │   ├── Controllers/   # 各类控制器脚本
│   │   ├── Enemy/         # 敌人脚本
│   │   ├── Skills/        # 技能脚本
│   │   ├── Player/        # 玩家脚本
│   │   ├── Stats/         # 数值系统脚本
│   │   └── UI/            # UI
│   ├── TextMesh Pro/
│   └── Tile Palette/
├── ProjectSettings/
├── UserSettings/
├── BugLog.txt/            # 修bug日志
├── MyDesign.txt/          # 我的一些设计和思考
└── README.md
```

> 注：只列举主要结构，目录结构可能随着重构与功能增加而调整。





---

本项目为个人学习与实践项目，持续更新中。
