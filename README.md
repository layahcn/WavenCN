# Waven汉化启动器

![avatar](https://pan.layah.workers.dev/1:/WLpic.png)

| 汉化启动器版本 | 汉化补丁包版本 | 适用游戏版本 | 适用战网版本 |
| :-: | :-: | :-: | :-: |
| 1.2.23.1 | 2021.2.27-V1 | 0.7.2.23502 | 3.2.6 |

## 使用说明：

【第一次使用汉化启动器建议按以下流程操作】
1. 本软件需安装微软.NET 框架(Runtime) 4.7.2以上版本才能正常使用诸如下载、解压等功能（18年之后的Windows系统自带）
  - 下载地址一：[微软官方下载](https://dotnet.microsoft.com/download/dotnet-framework/net472)
  - 下载地址二：[备用离线完整安装包](https://ankamacn.coding.net/api/share/download/922fd231-7211-487e-818e-de87d8134ba6)
2. 下载汉化启动器`WavenLauncher.exe`到任意一个**非系统盘的空文件夹**内以便于管理
  - 下载地址一：[Github Release页面](https://github.com/layahcn/WavenCN/releases)
  - 下载地址二：[个人网盘Waven文件夹内](http://www.oupai.pw/download/)
3. 打开汉化启动器`WavenLauncher.exe`
  - 由于战网从3.2.5版本开始，默认安装路径改为系统盘Program Files文件夹，所以需要以**管理员权限**运行汉化启动器才能对战网进行汉化等操作
  - 打开汉化启动器时会根据`设置`里的`下载线路`自动检测软件、汉化补丁包以及游戏的最新版本，需稍等片刻，检测失败可尝试切换至`国际下载线路`
  - 若汉化启动器多次处于检测失败状态，请确认是否能打开[官方服务器版本发布页](https://launcher.cdn.ankama.com/cytrus.json)
4. 下载安装**Ankama战网**，若已安装过最新版战网，在汉化启动器`设置`里`选择战网路径`
  - 方式一：[官方下载途经](https://www.ankama.com/en/launcher)
  - 方式二：点击汉化启动器右下角`下载战网`或`设置`里战网版本号可下载战网硬盘版，下载失败可尝试切换至`国际下载线路`
5. 打开Ankama战网登录Ankama账户，无账户可按[教程](https://www.bilibili.com/read/cv9232061)进行注册
  - 若需要战网的汉化可以勾选汉化启动器`设置`里`启用战网汉化`，然后点击`启动战网`，软件会替换`en.json`文件的方式汉化战网，所以战网语言需选择**英语English**
6. 下载安装**Waven游戏**
  - 方式一：Ankama战网里下载安装游戏，当没下载速度了可尝试暂停后重试
  - 方式二：点击汉化启动器`设置`里游戏版本号可下载游戏硬盘版，下载失败可尝试切换至`国际下载线路`（PS目前硬盘版是0.7.0版本，还需用战网更新大概30MB
7. 确保游戏安装完成后并且可以打开的前提下，在汉化启动器`设置`里`选择游戏路径`并`保存`
8. 点击汉化启动器`汉化游戏`，战网里游戏的语言设置请选**法语Francais**，方可汉化成功，之后就可以退出本软件了

【下一次打开汉化版游戏建议按以下流程操作】
1. 首先打开Waven汉化启动器`WavenLauncher.exe`，检测到有最新汉化文件时会自动下载`Waven-zh-cn.zip`到`WLDownload`文件夹
2. 在勾选`自动安装汉化`的情况下，会自动解压`Waven-zh-cn.zip`并替换游戏文件（无法使用本软件或Mac端的就手动解压替换）
3. 点击汉化启动器`启动战网`，随后点击战网里的**Play**或**开始游戏**即可（若未勾选`自动安装汉化`则先点击汉化启动器`汉化游戏`）

【补充说明】
- 官方下载途径的战网和游戏可以自行设置安装路径，通过本汉化启动器下载则都是默认装到C盘，安装好的游戏可以通过战网移动到别的盘
- 若汉化出现乱码等问题可点击战网的**修复Repair**或取消勾选汉化启动器的`启用游戏汉化`，此时会下载`Waven-fr-fr.zip`解压替换游戏文件
- 若检测到游戏汉化补丁包对应的游戏版本落后于最新游戏版本，`自动安装汉化`的功能则不会生效
- 游戏里打开设置→社交→表情项旁边有当前已安装的汉化补丁包的版本号，可用于确认是否为最新版
- 校验及解压大文件时软件会无响应，这是正常现象，因为没有添加异步处理，目前只有下载和检测更新操作是异步
- 汉化启动器下载的文件都在同目录下的`WLDownload`文件夹，视情况可自行清理
- 国内下载线路服务器为上海市腾讯云，国际下载线路服务器为美国Cloudflare节点
- 使用过程中出现任何问题请提交Issue或[加Waven游戏Q群：820110084](https://jq.qq.com/?_wv=1027&k=NdAUkl52)

## 汉化启动器更新日志：

### 1.2.23.1
- 适配游戏Alpha 0.7.0版以及新版战网
- 添加基于Cloudflare的[国际下载线路](http://www.oupai.pw/download/)
- 添加自动安装汉化功能，节省操作
- 添加校验文件MD5码功能，避免重复下载及重复安装
- 添加从官方服务器检测最新版本的功能
- 添加判断本地游戏文件版本与状态的功能
- 添加自定义战网路径的功能
- 添加最小化按钮
- 储存资源更新发布页由Lofter改为Coding
- 异步获取更新资源页，避免打开软件时假死
- 更换版本号显示格式
- 回显信息带时间戳逐条显示
- 修复更新软件后不继承旧版用户设置的问题
- 修复解压文件时跳过无扩展名文件的问题
- 其他亿点细节的优化

<details>
  <summary>汉化启动器旧版日志</summary>
  
### 202101011
- 修复了汉化启动器在中文及带空格路径时，无法自爆更新的问题

### 202012181
- 更新适配0.6.1版本以及新版战网

### 202012161
- 适配游戏Alpha 0.6版以及新版战网
- 添加下载游戏硬盘版的功能
- 添加显示下载速度和已下载文件大小
- 添加恢复原版游戏文件的功能
- 更换下载来源为Coding网盘（单文件最大支持300MB）
- 优化选择游戏路径时的默认地址
- 优化取消下载功能
- 修复一些情况下拖动窗口未释放的问题
- 其他亿点细节的改动

### 201910241
- 适配Alpha 0.4版以及新版战网
- 更新了下载汉化文件的地址

### 201908241
- 正式发布完整汉化版
- 修复字体显示，统一设置为微软雅黑

### 201908152
- 增加了游戏语言选择法语的提示
- 没有修复任何bug

### 201908151
- Waven汉化启动器内测版伴随着bug提前发布。
</details>

## 汉化补丁包更新日志：

### 2021.2.27-V1
- 更新文本适配到Alpha 0.7.2版本

### 2021.2.25-V1
- 更新文本适配到Alpha 0.7.1版本

### 2021.2.23-V1
- 更新文本适配到Alpha 0.7.0版本

<details>
  <summary>汉化补丁包旧版日志</summary>

### 202101011
- Alpha 0.6.2版本基本全部汉化

### 202012261
- 添加了法术天赋装备佣兵等翻译
- 添加了群友yo的中文输入补丁

### 202012181
- 更新文本适配到Alpha 0.6.1版本
- 调整了按钮字体大小
- 界面ui基本汉化

### 202012161
- 更新文本适配到Alpha 0.6.0版本

-=201911131=-
更新文本适配到Alpha 0.4.5版本

-=201911061=-
更新文本适配到Alpha 0.4.4版本

-=201910301=-
更新文本适配到Alpha 0.4.2版本

-=201910251=-
更新文本适配到Alpha 0.4.1版本

-=201910241=-
更新文本适配到Alpha 0.4.0版本
尚有大量改动文本未修改

-=201908241=-
更新文本适配游戏0.3.5版本；
添加了安妮丽莎和凯拉条目的翻译

-=201908211=-
更新文本适配游戏0.3.4版本

-=201908201=-
添加了斯拉姆条目的翻译

-=201908181=-
添加了撒克雅和佣兵条目的翻译；
现在可以在设置的社交选项里表情标题查看游戏汉化文本的版本了

-=201908152=-
添加了械勒条目的翻译

-=201908151=-
界面、骑士条目翻译基本完成
</details>

## 汉化补丁包制作：

如果你想自制汉化补丁可以使用以下工具：
- [Unity Assets Bundle Extractor](https://github.com/DerPopo/UABE)：替换游戏文本
- [dnSpy](https://github.com/dnSpy/dnSpy)：反编译源代码

题外话——如果单纯想提取游戏资源那么就用：
- [AssetStudio](https://github.com/Perfare/AssetStudio)：快速预览图片
- [python-fsb5](https://github.com/HearthSim/python-fsb5)：转换音频资源

## 软件及汉化补丁包许可：

![avatar](data:image/png;base64,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)
<br />本软件及汉化补丁采用<a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/4.0/">知识共享署名-非商业性使用-相同方式共享 4.0 国际许可协议</a>进行许可。