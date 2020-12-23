#!/bin/bash
if [ "$LC_ALL" = "zh_CN.UTF-8" ] ; then
	read -p "按下RETURN以继续..."
else
	read -p "Press RETURN to continue..."
fi
echo -e "\n"
if [ ! -d "/Library/Developer/CommandLineTools/usr" ] ; then
	if [ "$LC_ALL" = "zh_CN.UTF-8" ] ; then
		echo "请安装Xcode CLT，已触发安装提示，并请在安装完成之后再次运行本脚本。"
	else
		echo "Triggering installation of Xcode CLT, please restart the script after install finished. "
	fi
	exit
else
	if [ "$LC_ALL" = "zh_CN.UTF-8" ] ; then
		echo "正在重新签名，请在下方输入密码（不会有回显）"
	else
		echo "Resigning application, please type your password below (there is no feedback when entering password)"
	fi
	sudo codesign -fs - --deep "/Applications/Corona Virus Interactive Movie.app"
	if [ "$LC_ALL" = "zh_CN.UTF-8" ] ; then
		echo "签名成功，您可以关闭这个窗口了。"
	else
		echo "Success, you may close this window now. "
	fi
fi
