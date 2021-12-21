<div align=center>

# Waven汉化启动器

![Interface](https://pan.layah.workers.dev/1:/WLpic.png)    
![汉化启动器版本](https://img.shields.io/badge/%E6%B1%89%E5%8C%96%E5%90%AF%E5%8A%A8%E5%99%A8%E7%89%88%E6%9C%AC-1.12.22.1-brightgreen)
![汉化补丁包版本](https://img.shields.io/badge/%E6%B1%89%E5%8C%96%E8%A1%A5%E4%B8%81%E5%8C%85%E7%89%88%E6%9C%AC-2021.12.22--V1-red)
![适用游戏版本](https://img.shields.io/badge/%E9%80%82%E7%94%A8%E6%B8%B8%E6%88%8F%E7%89%88%E6%9C%AC-0.9.1.31347-blue)
![适用战网版本](https://img.shields.io/badge/%E9%80%82%E7%94%A8%E6%88%98%E7%BD%91%E7%89%88%E6%9C%AC-3.5.10-orange)

</div>

## 使用说明：

### 【首次配置流程】
1. 下载汉化启动器`WavenLauncher.exe`到任意一个**非系统盘的空文件夹**内以便于管理
    - 下载地址一：[Github Release页面](https://github.com/layahcn/WavenCN/releases)
    - 下载地址二：[个人网盘Waven文件夹内](http://www.oupai.pw/download/)
2. 打开汉化启动器`WavenLauncher.exe`
    - 若提示需安装4.7.2版本的.NET 框架，则下载[微软官方在线安装包](https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net472-web-installer)或[备用离线完整安装包](https://ankamacn.coding.net/s/922fd231-7211-487e-818e-de87d8134ba6)
    - 由于战网从3.2.5版本开始，默认安装路径改为系统盘Program Files文件夹，所以需要以**管理员权限**运行汉化启动器才能对战网进行汉化等操作
    - 打开汉化启动器时会根据`设置`里的`下载线路`自动检测软件、汉化补丁包以及游戏的最新版本，需稍等片刻
3. 下载安装**Ankama战网**，若已安装过最新版战网，在汉化启动器`设置`里`选择战网路径`
    - 方式一：[官方下载途经](https://www.ankama.com/en/launcher)
    - 方式二：点击汉化启动器右下角`下载战网`或`设置`里战网版本号可下载战网硬盘版，下载失败可尝试切换至`国际下载线路`
4. 打开Ankama战网登录Ankama账户
    - 若需要战网的汉化可以勾选汉化启动器`设置`里`启用战网汉化`，然后点击`启动战网`，软件会替换`en.json`文件的方式汉化战网，所以战网语言需选择**英语English**
5. 下载安装**Waven游戏**
    - 方式一：Ankama战网里下载安装游戏，当没下载速度了可尝试暂停后重试
    - 方式二：点击汉化启动器`设置`里游戏版本号可下载游戏硬盘版，下载失败可尝试切换至`国际下载线路`
6. 打开游戏确保可以正常进入后关闭游戏，在汉化启动器`设置`里`选择游戏路径`并`保存`
7. 点击汉化启动器`汉化游戏`，战网里游戏的语言设置请选**法语Francais**，方可汉化成功，之后就可以退出本软件了

### 【一般使用流程】
1. 首先打开Waven汉化启动器`WavenLauncher.exe`，检测到有最新汉化文件时会自动下载`Waven-zh-cn.zip`到`WLDownload`文件夹
2. 在勾选`自动安装汉化`的情况下，会自动解压`Waven-zh-cn.zip`并替换游戏文件
3. 点击汉化启动器`启动战网`，随后点击战网里的**Play**或**开始游戏**即可（若未勾选`自动安装汉化`则先点击汉化启动器`汉化游戏`）

### 【常见问题】
1. 我没有Ankama账户，我该如何注册？  
> 按[教程](https://www.bilibili.com/read/cv9232061)通过Steam注册，若未找到steam登录ankama入口，[请点此](https://account.ankama.com/auth/steam?from=https%3A%2F%2Faccount.ankama.com%2Fen)。注意使用真实ip，仅使用某易UU加速器代理Steam社区即可，否则大概率会提示ip不可用。用steam登录进官网后，在个人信息页找到steam编辑按钮，设置账户登录用绑定邮箱及登录密码；之后完善个人信息、设置好密保问题，即可使用账户登录战网了。  
2. 为什么战网无限更新，然后自动关闭了？  
> 一般是战网更新失败导致的，点击汉化启动器`设置`里战网版本号强制下载更新战网即可。不推荐手动解压使用的方式，容易形成过多无用的旧版目录。  
3. 战网无法登录进去，显示IP地址隐藏？  
> 请关闭VPN等科学上网手段，使用真实IP进行登录。若属于IP误封等情况，请[联系客服](http://support.ankama.com/)提交工单，PS客服网站的账户密码完全独立，并且可能需要翻墙。
4. 为什么打开游戏黑屏，只有左下角显示版本号？  
> 原因可能是检测不到时区，可在`%USERPROFILE%\AppData\Roaming\zaap\waven\waven.log`中确认是否有`TimeZoneNotFoundException`关键词。解决办法就是系统时区调成自动获取或直接设置后再尝试打开游戏。  
5. 我不是Windows系统或不想使用汉化启动器，但我想使用汉化补丁，如何手动安装？  
> 手动下载`Waven-zh-cn.zip`解压至游戏目录内，询问替换则确定即可。[下载地址一](https://ankamacn.coding.net/p/coding-devops-guide/d/coding-devops-guide/git/raw/master/Waven-zh-cn.zip?download=true)，[下载地址二](http://www.oupai.pw/download/)(Waven文件夹内)
6. 为什么用汉化启动器安装战网时解压错误，提示拒绝访问？  
> 退出360等辣鸡安全软件，或将汉化启动器及战网目录加入白名单。  

### 【补充说明】
1. 官方下载途径的战网和游戏可以自行设置安装路径，通过本汉化启动器下载则都是默认装到C盘，安装好的游戏可以通过战网移动到别的盘
2. 汉化启动器下载的文件都在同目录下的`WLDownload`文件夹内，视情况可自行清理
3. 若汉化出现乱码等问题可点击战网的**修复Repair**或取消勾选汉化启动器的`启用游戏汉化`，此时会下载`Waven-fr-fr.zip`原版游戏文件解压并替换
4. 游戏里打开设置→社交→表情项旁边有当前已安装的汉化补丁包的版本号，可用于确认是否为最新版
5. 校验及解压大文件时软件会无响应，这是正常现象，因为没有添加异步处理，目前只有下载和检测更新操作是异步
6. 国内下载线路服务器为上海市腾讯云，国际下载线路服务器为美国Cloudflare节点
7. 使用过程中出现任何问题请[提交Issue](https://github.com/layahcn/WavenCN/issues)或[加Waven游戏Q群：820110084](https://jq.qq.com/?_wv=1027&k=NdAUkl52)

## 汉化启动器更新日志：

### 1.12.22.1
- 适配游戏Alpha 0.9.1版以及新版战网
- 修复战网版本号及汉化版本号显示不完整问题

### 1.10.27.2
- 修复卡在`汉化游戏`按钮的问题

### 1.10.27.1
- 适配游戏Alpha 0.8.4版以及新版战网
- 添加判断本地NET框架版本的功能
- 添加检测游戏服务器延迟的功能
- 添加估算下载剩余时间的功能，下载速度改为瞬时速度
- 添加窗口置顶特性，启动战网后取消置顶
- 添加主按钮文本与动作一致性判断，防止误操作
- 添加官方最新版本页备用镜像，检测更新失败即启用
- 修复任务栏图标未显示的问题
- 修复国内下载线路失效的问题
- 修复同游戏版本下不同汉化补丁版本的校验问题
- 完善校验文件MD5值功能，避免下载链接失效导致的问题
- 其他亿点细节的优化

<details>
  <summary>汉化启动器旧版日志</summary>

> ### 1.2.23.1
> - 适配游戏Alpha 0.7.0版以及新版战网
> - 添加基于Cloudflare的[国际下载线路](http://www.oupai.pw/download/)
> - 添加自动安装汉化功能，节省操作
> - 添加校验文件MD5码功能，避免重复下载及重复安装
> - 添加从官方服务器检测最新版本的功能
> - 添加判断本地游戏文件版本与状态的功能
> - 添加自定义战网路径的功能
> - 添加最小化按钮
> - 储存资源更新发布页由Lofter改为Coding
> - 异步获取更新资源页，避免打开软件时假死
> - 更换版本号显示格式
> - 回显信息带时间戳逐条显示
> - 修复更新软件后不继承旧版用户设置的问题
> - 修复解压文件时跳过无扩展名文件的问题
> - 其他亿点细节的优化
> 
> ### 202101011
> - 修复了汉化启动器在中文及带空格路径时，无法自爆更新的问题
> 
> ### 202012181
> - 更新适配0.6.1版本以及新版战网
> 
> ### 202012161
> - 适配游戏Alpha 0.6版以及新版战网
> - 添加下载游戏硬盘版的功能
> - 添加显示下载速度和已下载文件大小
> - 添加恢复原版游戏文件的功能
> - 更换下载来源为Coding网盘（单文件最大支持300MB）
> - 优化选择游戏路径时的默认地址
> - 优化取消下载功能
> - 修复一些情况下拖动窗口未释放的问题
> - 其他亿点细节的改动
> 
> ### 201910241
> - 适配Alpha 0.4版以及新版战网
> - 更新了下载汉化文件的地址
> 
> ### 201908241
> - 正式发布完整汉化版
> - 修复字体显示，统一设置为微软雅黑
> 
> ### 201908152
> - 增加了游戏语言选择法语的提示
> - 没有修复任何bug
> 
> ### 201908151
> - Waven汉化启动器内测版伴随着bug提前发布。

</details>

## 汉化补丁包更新日志：

### 2021.12.22-V1
- 更新文本适配到Alpha 0.9.1版本

### 2021.11.4-V1
- 更新文本适配到Alpha 0.8.6版本

### 2021.10.28-V1
- 更新文本适配到Alpha 0.8.5版本
- 将未翻译的法语替换成Maufeat制作的英文版

### 2021.10.27-V1
- 更新文本适配到Alpha 0.8.4版本
- 由于UABE工具没有适配游戏所用的Unity版本，因此改为参照Maufeat的方法读取Json进行汉化
- 感谢苦力QingYing、evenKY、Juhun以及过去众群友帮忙翻译

<details>
  <summary>汉化补丁包旧版日志</summary>

> ### 2021.3.4-V1
> - 戒指、天赋和武器法术翻译完成
> 
> ### 2021.2.27-V1
> - 更新文本适配到Alpha 0.7.2版本
> 
> ### 2021.2.25-V1
> - 更新文本适配到Alpha 0.7.1版本
> 
> ### 2021.2.23-V1
> - 更新文本适配到Alpha 0.7.0版本
> 
> ### 202101011
> - Alpha 0.6.2版本基本全部汉化
> 
> ### 202012261
> - 添加了法术天赋装备佣兵等翻译
> - 添加了群友yo的中文输入补丁
> 
> ### 202012181
> - 更新文本适配到Alpha 0.6.1版本
> - 调整了按钮字体大小
> - 界面ui基本汉化
> 
> ### 202012161
> - 更新文本适配到Alpha 0.6.0版本
> 
> ### 201911131
> - 更新文本适配到Alpha 0.4.5版本
> 
> ### 201911061
> - 更新文本适配到Alpha 0.4.4版本
> 
> ### 201910301
> - 更新文本适配到Alpha 0.4.2版本
> 
> ### 201910251
> - 更新文本适配到Alpha 0.4.1版本
> 
> ### 201910241
> - 更新文本适配到Alpha 0.4.0版本
> - 尚有大量改动文本未修改
> 
> ### 201908241
> - 更新文本适配游戏0.3.5版本；
> - 添加了安妮丽莎和凯拉条目的翻译
> 
> ### 201908211
> - 更新文本适配游戏0.3.4版本
> 
> ### 201908201
> - 添加了斯拉姆条目的翻译
> 
> ### 201908181
> - 添加了撒克雅和佣兵条目的翻译；
> - 现在可以在设置的社交选项里表情标题查看游戏汉化文本的版本了
> 
> ### 201908152
> - 添加了械勒条目的翻译
> 
> ### 201908151
> - 界面、骑士条目翻译基本完成

</details>

## 汉化补丁包制作：

如果你想自制汉化补丁可以使用以下工具：
- [Unity Assets Bundle Extractor](https://github.com/DerPopo/UABE)：替换游戏文本
- [UABEA](https://github.com/nesrak1/UABEA)：上款替代方案
- [dnSpy](https://github.com/dnSpy/dnSpy)：反编译源代码

题外话——如果单纯想提取游戏资源那么就用：
- [AssetStudio](https://github.com/Perfare/AssetStudio)：快速预览图片
- [python-fsb5](https://github.com/HearthSim/python-fsb5)：转换音频资源

## 软件及汉化补丁包许可：

![avatar](https://pan.layah.workers.dev/1:/by-nc-sa.png)
<br />本软件及汉化补丁采用<a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/4.0/">知识共享署名-非商业性使用-相同方式共享 4.0 国际许可协议</a>进行许可。
