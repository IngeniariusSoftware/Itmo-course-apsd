input = open('input.txt');
length = int(input.readline());
tokens = input.readline().split(' ');
tokens = [float(element) for element in tokens]
input.close();
output = open('output.txt' , 'w');
sort = sorted(tokens);
output.write(str(tokens.index(sort[0]) + 1) + ' ' + str(tokens.index(sort[(length - 1) // 2]) + 1) + ' ' + str(tokens.index(sort[length -1]) + 1));
output.close();
