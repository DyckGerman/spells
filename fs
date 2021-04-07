lsblk -o NAME,HCTL,SIZE,MOUNTPOINT | grep -i "sd"
iostat -dx /dev/sdb 5
parted /dev/sda --script mklabel gpt mkpart ext4part ext4 0% 100%
mkfs.ext4 /dev/sdb1
pcre2grep -o1 'sda(?:\s*[\d*.\d*]*){0}\s*([\d*.\d*]*).*'

sudo mount -a
blkid
