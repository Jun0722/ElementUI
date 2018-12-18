<template>
  <el-row class="container">
    <el-col :span="24" class="header">
      <el-col :span="5" class="logo" :class="isCollapse?'logo-collapse-width':'logo-width'">
        <img :src="this.logo">
        {{isCollapse?sysName:sysName}}
      </el-col>
      <el-col :span="1">
        <div class="tools" @click.prevent="collapse">
          <i class="el-icon-menu"></i>
        </div>
        <!-- <i class="fa fa-align-justify"></i> -->
      </el-col>
      <el-col :span="13">
        <div class="hearNavBar">
          <el-menu
            :default-active="activeIndex"
            class="el-menu-demo"
            background-color="#4b5f6e"
            text-color="#fff"
            active-text-color="#ffd04b"
            mode="horizontal"
            @select="handleSelectHearNavBar"
          >
            <el-menu-item index="1">首页</el-menu-item>
            <el-menu-item index="2">消息中心</el-menu-item>
            <el-menu-item index="3">订单管理</el-menu-item>
          </el-menu>
        </div>
      </el-col>
      <el-col :span="5" class="userinfo">
        <el-dropdown @command="handleCommand">
          <span class="el-dropdown-link userinfo-inner">
            中文
            <i class="el-icon-arrow-down el-icon--right"></i>
          </span>
          <el-dropdown-menu slot="dropdown">
            <el-dropdown-item command="zh">中文</el-dropdown-item>
            <el-dropdown-item command="en">English</el-dropdown-item>
          </el-dropdown-menu>
        </el-dropdown>

        <el-dropdown trigger="hover">
          <span class="el-dropdown-link userinfo-inner">
            <img :src="this.userAvatar">
            {{username}}
          </span>
          <el-dropdown-menu slot="dropdown">
            <el-dropdown-item>我的消息</el-dropdown-item>
            <el-dropdown-item>设置</el-dropdown-item>
            <el-dropdown-item divided @click.native="logout">退出登录</el-dropdown-item>
          </el-dropdown-menu>
        </el-dropdown>
      </el-col>
    </el-col>
    <el-col :span="24" class="main">
      <aside class="aside">
        <!--导航菜单-->
        <el-menu
          default-active="1-3"
          class="el-menu-vertical-demo"
          @open="handleopen"
          @close="handleclose"
          @select="handleselect"
          :collapse="isCollapse"
        >
          <el-submenu index="1">
            <template slot="title">
              <i class="el-icon-location"></i>
              <span slot="title">导航一</span>
            </template>
            <el-menu-item index="1-1" @click="$router.push('user')">{{$t("sys.userMng")}}</el-menu-item>
            <el-menu-item index="1-2" @click="$router.push('menu')">{{$t("sys.menuMng")}}</el-menu-item>
          </el-submenu>
          <el-menu-item index="2">
            <i class="el-icon-menu"></i>
            <span slot="title">导航二</span>
          </el-menu-item>
          <el-menu-item index="3" disabled>
            <i class="el-icon-document"></i>
            <span slot="title">导航三</span>
          </el-menu-item>
          <el-menu-item index="4">
            <i class="el-icon-setting"></i>
            <span slot="title">导航四</span>
          </el-menu-item>
        </el-menu>
      </aside>
      <section class="content-container">
        <div class="grid-content bg-purple-light">
          <el-col :span="24" class="breadcrumb-container">
            <el-breadcrumb separator="/" class="breadcrumb-inner">
              <el-breadcrumb-item v-for="item in $route.matched" :key="item.path">{{ item.name }}</el-breadcrumb-item>
            </el-breadcrumb>
          </el-col>
          <el-col :span="24" class="content-wrapper">
            <transition name="fade" mode="out-in">
              <router-view></router-view>
            </transition>
          </el-col>
        </div>
      </section>
    </el-col>
  </el-row>
</template>

<script>
import axios from "axios";
// import mock from '@/mock/mock.js'
import mock from "@/mock/index.js";
export default {
  data() {
    return {
      userName: "Louis",
      userAvatar: "",
      activeIndex: "1",
      backupVisible: false
    };
  },
  methods: {
    // 折叠导航栏
    onCollapse: function() {
      this.$store.commit("onCollapse");
    },
    //语言切换
    handleCommand(command) {
      let lang = command === "" ? "zh" : command;
      this.$i18n.locale = lang;
    },
    // 退出登录
    logout: function() {
      this.$confirm("确认退出吗?", "提示", {
        type: "warning"
      })
        .then(() => {
          sessionStorage.removeItem("user");
          this.$router.push("/login");
          this.$api.login
            .logout()
            .then(res => {})
            .catch(function(res) {});
        })
        .catch(() => {});
    }
  },
  mounted() {
    this.sysName = "Kitty Platform";
    var user = sessionStorage.getItem("user");
    if (user) {
      this.userName = user;
      this.userAvatar = require("@/assets/user.png");
    }
  }
};
</script>
<style scoped lang="scss">
.container {
  position: absolute;
  left: 200px;
  right: 0px;
  height: 60px;
  line-height: 60px;
  .hamburger-container {
    width: 40px;
    float: left;
    border-color: rgba(238, 241, 241, 0.4);
    border-left-width: 1px;
    border-left-style: solid;
    border-right-width: 1px;
    border-right-style: solid;
    color: white;
  }
  .nav-bar {
    margin-left: auto;
    float: left;
    .el-menu {
      background: #0a463480;
    }
  }
  .tool-bar {
    float: right;
    .theme-picker {
      padding-right: 10px;
    }
    .lang-selector {
      padding-right: 10px;
      font-size: 15px;
      color: #fff;
      cursor: pointer;
    }
    .user-info-dropdown {
      font-size: 20px;
      padding-right: 20px;
      color: #fff;
      cursor: pointer;
      img {
        width: 40px;
        height: 40px;
        border-radius: 10px;
        margin: 10px 0px 10px 10px;
        float: right;
      }
    }
  }
}
.menu-bar-width {
  left: 200px;
}
.menu-bar-collapse-width {
  left: 65px;
}

.menu-bar-container {
  .el-menu {
    position: absolute;
    top: 60px;
    bottom: 0px;
    text-align: left;
    // background-color: #2968a30c;
  }
  .logo {
    position: absolute;
    top: 0px;
    height: 60px;
    line-height: 60px;
    background: #545c64;
    cursor: pointer;
    img {
      width: 40px;
      height: 40px;
      border-radius: 0px;
      margin: 10px 10px 10px 10px;
      float: left;
    }
    div {
      font-size: 25px;
      color: white;
      text-align: left;
      padding-left: 20px;
    }
  }
  .menu-bar-width {
    width: 200px;
  }
  .menu-bar-collapse-width {
    width: 65px;
  }
}

.container {
  position: absolute;
  top: 60px;
  left: 0px;
  // background: rgba(202, 243, 227, 0.1);
  .breadcrumb {
    padding: 10px;
    border-color: rgba(148, 145, 147, 0.2);
    border-bottom-width: 1px;
    border-bottom-style: solid;
  }
  .content {
    margin-bottom: 5px;
    padding-top: 5px;
    margin-left: 2px;
    // background: rgba(209, 212, 212, 0.1);
  }
}
.menu-bar-width {
  left: 200px;
}
.menu-bar-collapse-width {
  left: 65px;
}
</style>
