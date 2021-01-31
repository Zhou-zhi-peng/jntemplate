# 更新日志
## Version 2.0.0
***
更新日期：待更新

- 功能
	- 1.架构调整，接口调整，由原来解释型模板引擎重构为编译型模板引擎
	- 2.支持预编译，未预编译模板，在第一次执行时自动编译。
	- 3.增加加载器概念,通过自定义加载器,可以从文件,FTP,HTTP等多种方式与途迳加载模板
	- 4.增加了layout标签,功能类似于razor中的layout或aspx中的母版页（其它模板引擎中的block），
	- 5.增加了索引语法,比如row["name"],为了保持向后兼容，原row.name在当前版本中将继续支持。
	- 6.增加异步方法支持，允许模板调用异步方法。
	- 7.增加静态方法支持，允许模板调用静态方法。

- 优化
	- 1.结构优化，性能提升。

- 其它
	- 注意，从该本版开始不再支持.net framework 4.0以下框架(.net framework 2.0/3.5)
	- 注意，本次为大版本升级，部分接口与以前不兼容，如选择升级，请注意相关风险
	- 调整框架支持如下：
	- 1. .net framework 4.0 以上或对应的mono版本
	- 2. .net core 2.1 以上
	- 3. .netstandard 2.1 以上
	- 4. .net 5.0


## Version 1.4.0
***
更新日期：2021-01-17

- 功能
	- 1.增加加载器概念,通过自定义加载器,可以从文件,FTP,HTTP等多种方式与途迳加载模板
	- 2.增加了layout标签,功能类似于razor中的layout或aspx中的母版页（其它模板引擎中的block），
	- 3.增加了索引语法,比如row["name"],为了保持向后兼容，原row.name在当前版本中将继续支持。
	- 4.修复一个逻辑运算处理不当有可能引发异常的BUG
	- 5.增加异步方法支持，增加了一些.NET CORE相关特性，调整了一些类的构造函数，方便DI注入

- 优化
	- 1.简化了foreach标签与elseif标签的写法(原写法同样支持)
		- foreach in 支持简写成 for in
		- elseif 支持简写成 elif
	- 2.调整了配置参数
	- 3.调整了代码的命名空间层次,使结构更清晰
	- 4.去掉了一些冗余设计

- 其它
	- 授权由apache 2.0 变更为更简单宽松的MIT
	- 本版本为1.X的长期支持版本，1.X版本以后不再更新，仅进行BUG修复
	- 调整框架支持如下：
	- 1. .net framework 2.0 以上
	- 2. .net core 2.1 以上
	- 3. .netstandard 2.0 以上

## Version 1.3.3
***
更新日期：2018-04-27
- 修复一处逆波兰表达式运算的BUG


## Version 1.3.2
***
更新日期：2017-09-13

- 增加.Net Core支持(1.1+)
- 修复计算表达式时有可能超出预期的问题
- 修复方法标签实参为负数时无法识别的问题
- 增加.Net Standard支持
 
## Version 1.3.1
***
更新日期：2016-12-01

- 修复一处BUG
- 优化IL（暂定）
- 修复在模板中访问不存在属性会显示父对象的问题
- 调整了Engine类
  1. 调整了 Engine.Configure() 重载
  2. 原Engine.Runtime中的所有内容全移入Engine下并移除了Runtime（减少调用层次）
  3. 增加 Engine.SetEnvironmentVariable(配置自定义变量) Engine.GetEnvironmentVariable（获取自定义变量）

## Version 1.3.0
***
更新日期：2015-10-16

- 为了避免引擎使用复杂化，以下写法不再支持（统一到Engine静态类下）：
  1. 从指定文件加载模板：Template.FromFile(String, Encoding)方法已删除！ 替代方法： Engine.LoadTemplate(String,TemplateContext) 
  2. 全局配置入口：JinianNet.JNTemplate.BuildManager 类已删除！ 替代方法：Engine.Configure() +2 重载
  3. 模板查找目录：Resources.Paths/TemplateContext.Paths 属性已删除！替代属性：Engine.Runtime.ResourceDirectories

- 功能性开发：
- 增加引擎配置入口
- 支持标签注释
- 支持自定义标签前后缀
- 增加标签空白字符处理开关
- 增加大小写配置开关

## Version 1.2.3
***
更新日期：2015-09-16

- 调整foreach循环体内，使用set标签时的作用域问题
- 修正一个某特定情况下计算表达式时异常的BUG
- 优化了方法标签解析时形参处理，增加params支持
- 修复逻辑运算中的一个BUG
- 1.2.x 版本除BUG修复外不再更新！

## Version 1.2.2
***
更新日期：2014-02-23

- BUG修复：
- 1.修复计算表达式返回类型不准确引发的for标签循环异常
- 2.修复空格引发字符串判断异常
- 3.修复了IF判断时类型限制问题
- 4.调整了for的一个默认设定
- 5.调整了解析时某些异常提示不明确的问题


## Version 1.2.1
***
更新日期：2014-08-14

- bug 修复
- 增加了异常提示
- 路径优化 兼容liunx
- 版本号显示调整


## Version 1.2.0
***
更新日期：2014-07-28

- 增加了for标签
- 增加elseif支持
- 增加Reference标签
- 标签分析部分结构变更优化
- 增加了详细注释


## Version 1.1.0
***
更新日期：2013-03-18

- 框架整体结构进行了重构，性能优化
- 标签前缀由以前的“#{”变更为“${”
- 增加标签简写支持，比如${ Site.Title } 可以简写为 $Site.Title
- 简化了组合标签写法，比如原#{#if(3>5)} 现在 可写作 ${if(3>5)} 或者简写为 $if(3>5)
- 调整SET标签语法:#{set n=5} 变更为 ${set(n=5)}(简写：$set(n=5))
- 增加了Include标签！


## Version 1.0.3
***
更新日期：2011-12-05

- 初始版本