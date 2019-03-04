### Keyboard layouts switch
```bash
setxkbmap -layout us,de
setxkbmap -option 'grp:alt_shift_toggle'
```

### Password expiration control
```bash
chage -d 2019-03-01 german
```

### Connect webcam to vbox vm
```bash
VBoxManage controlvm "w8" webcam attach /dev/video0
```
