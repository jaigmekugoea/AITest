# Prototype to Vue3 ElementUI HTML Generator

## Description
根据原型图快速生成 Vue3 + Element Plus (ElementUI 3.x) 的单页HTML文件。该skill可以分析原型图并生成可直接在浏览器中运行的完整HTML代码。

## Skill Metadata
- **name**: prototype-to-vue3-elementui
- **description**: 根据原型图生成Vue3 + Element Plus单页HTML
- **version**: 1.0.0

---

## Instructions

当用户提供原型图（截图、设计稿或UI描述）时，请按照以下步骤生成Vue3 + Element Plus单页HTML：

### 1. 分析原型图
- 识别页面布局结构（头部、侧边栏、内容区、底部等）
- 识别UI组件类型（表格、表单、按钮、对话框、卡片等）
- 识别交互逻辑（点击事件、数据绑定等）
- 识别颜色、字体等样式信息

### 2. 生成HTML代码
生成的HTML文件必须包含以下部分：

```html
<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>页面标题</title>
    <!-- 引入 Element Plus 样式 (版本锁定以确保稳定性) -->
    <link rel="stylesheet" href="https://unpkg.com/element-plus@2.9.1/dist/index.css">
    <!-- 引入 Vue 3 -->
    <script src="https://unpkg.com/vue@3.5.13/dist/vue.global.js"></script>
    <!-- 引入 Element Plus -->
    <script src="https://unpkg.com/element-plus@2.9.1"></script>
    <!-- 引入 Element Plus 图标 -->
    <script src="https://unpkg.com/@element-plus/icons-vue@2.3.1"></script>
    <style>
        /* 自定义样式 */
    </style>
</head>
<body>
    <div id="app">
        <!-- Vue 模板内容 -->
    </div>
    <script>
        const { createApp, ref, reactive, computed, onMounted } = Vue;
        
        const app = createApp({
            setup() {
                // 响应式数据
                // 方法
                // 返回模板使用的数据和方法
                return {
                    // ...
                };
            }
        });
        
        // 注册 Element Plus
        app.use(ElementPlus);
        
        // 注册所有图标
        for (const [key, component] of Object.entries(ElementPlusIconsVue)) {
            app.component(key, component);
        }
        
        app.mount('#app');
    </script>
</body>
</html>
```

### 3. Element Plus 常用组件映射

根据原型图中的UI元素，使用对应的Element Plus组件：

| 原型图元素 | Element Plus 组件 |
|-----------|------------------|
| 按钮 | `<el-button>` |
| 输入框 | `<el-input>` |
| 下拉选择 | `<el-select>` + `<el-option>` |
| 表格 | `<el-table>` + `<el-table-column>` |
| 表单 | `<el-form>` + `<el-form-item>` |
| 对话框/弹窗 | `<el-dialog>` |
| 卡片 | `<el-card>` |
| 标签页 | `<el-tabs>` + `<el-tab-pane>` |
| 分页 | `<el-pagination>` |
| 菜单 | `<el-menu>` + `<el-menu-item>` |
| 面包屑 | `<el-breadcrumb>` |
| 消息提示 | `ElMessage` |
| 确认框 | `ElMessageBox` |
| 加载 | `v-loading` 指令 |
| 日期选择 | `<el-date-picker>` |
| 时间选择 | `<el-time-picker>` |
| 开关 | `<el-switch>` |
| 单选 | `<el-radio>` + `<el-radio-group>` |
| 多选 | `<el-checkbox>` + `<el-checkbox-group>` |
| 上传 | `<el-upload>` |
| 树形控件 | `<el-tree>` |
| 步骤条 | `<el-steps>` |
| 进度条 | `<el-progress>` |
| 标签 | `<el-tag>` |
| 头像 | `<el-avatar>` |
| 徽章 | `<el-badge>` |
| 警告 | `<el-alert>` |
| 抽屉 | `<el-drawer>` |

### 4. 布局组件

使用Element Plus的布局组件创建页面结构：

- `<el-container>` - 外层容器
- `<el-header>` - 顶部区域
- `<el-aside>` - 侧边栏区域
- `<el-main>` - 主要内容区域
- `<el-footer>` - 底部区域
- `<el-row>` + `<el-col>` - 栅格布局

### 5. 代码规范

1. **命名规范**
   - 使用驼峰命名法命名变量和函数
   - 组件数据使用语义化命名

2. **响应式数据**
   - 使用 `ref()` 定义基本类型数据
   - 使用 `reactive()` 定义对象类型数据

3. **模拟数据**
   - 为表格、列表等组件提供合理的模拟数据
   - 数据应符合原型图展示的内容类型

4. **交互功能**
   - 实现基本的按钮点击事件
   - 实现表单数据绑定
   - 实现对话框的打开/关闭
   - 实现表格的增删改查模拟

5. **样式调整**
   - 根据原型图调整颜色、间距等样式
   - 使用CSS变量或内联样式进行自定义

### 6. 输出要求

1. 生成的HTML文件应当可以直接在浏览器中打开运行
2. 所有依赖通过CDN引入，无需本地安装
3. 代码结构清晰，添加必要的注释
4. 确保响应式布局在不同屏幕尺寸下正常显示

> **注意**: CDN方式适合快速原型开发和演示，但需要网络连接。如需离线使用或生产环境部署，建议使用npm安装依赖并通过构建工具打包。

### 7. 使用示例

**用户输入**: "请根据这个原型图生成一个用户管理页面"（附带原型图）

**输出**: 包含以下功能的完整HTML文件
- 顶部搜索栏
- 用户列表表格（包含姓名、邮箱、角色、状态等列）
- 新增/编辑用户对话框
- 分页组件
- 操作按钮（编辑、删除）

---

## Tips

1. 如果原型图模糊或不清晰，请询问用户具体的功能需求
2. 对于复杂页面，可以分模块生成并组合
3. 生成后建议用户在浏览器中测试，根据需要进行调整
4. 如需特定功能（如图表），可以额外引入ECharts等库
