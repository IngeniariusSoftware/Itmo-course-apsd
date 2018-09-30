input = open('input.txt');
length = int(input.readline());
tokens = input.readline().split(' ');
input.close();
output = open('output.txt' , 'w');
i = 0;
while i < length:
    j = 0;
    while (int(tokens[i]) >= int(tokens[j])) & (j < i):
        j += 1;
    if j < i:
        shelf = tokens[i];
        k = i;
        while k > j:
            tokens[k] = tokens[k - 1];
            k -= 1;
        tokens[j] = shelf;
        output.write(str(j + 1) + ' ');
    else:
        output.write(str(i + 1) + ' ');
    i += 1;
output.write('\n');
for element in tokens:
    output.write(element + ' ');
output.close();
