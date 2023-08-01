# CSharp_exercise
软构
void itoa_dec(char *buf, int value)
{
    char *p = buf;
    char *p1, *p2;
    int remainder;
  
    // 计算每一位数字
    do {
        remainder = value % 10;
        *p++ = remainder + '0';
    } while (value /= 10);
  
    // 终止字符串
    *p = 0;
  
    // 反转字符串
    p1 = buf;
    p2 = p - 1;
    while (p1 < p2) {
        char tmp = *p1;
        *p1 = *p2;
        *p2 = tmp;
        p1++;
        p2--;
    }
}
