input = open('input.txt');
output = open('output.txt' , 'w');
tokens = input.readline().split(' ');
input.close();
output.write(str(int(tokens[0]) + int(tokens[1]) ** 2));
output.close();
