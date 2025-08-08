# Enunciado

Escriba una función que reciba una cantidad entera de segundos y retorne un string que muestre esa cantidad en formato HH:MM:SS. NO utilizar la clase DateTime.

# Feedback

Formato Hora: El código no compila. Para qué usar System.ComponentModel.DataAnnotations, si nada en el script usa esta librería? Además, tampoco tiene System para leer o escribir de consola. Por otro lado, el formato no es correcto (ej. 36 segundos los imprime como 0:0.36, cuando se pidió con formato HH:MM:SS, implicando dos dígitos por unidad de tiempo - debería ser 00:00:36) (0.9 / 1.25)

# Notas Aclaratorias

Profe, siendo sincero, no tengo ni idea de como o por que saltó ese error. **Las variables Hou, Min y Sec son denominadas como enteros**, en ningún caso, al momento de imprimir, deberia mostrar un decimal, incluso con el ejemplo dado en el Feedback, este error no se da.
```cs
Console.WriteLine(Hou + ":" +  Min + ":" + Sec); 
//Mostrar tiempo en formato HH:MM:SS
```

Agrego anexo de imagen de prueba de como el programa lee el valor de input 35 y la respuesta que devuelve:

![Evidencia](https://media.discordapp.net/attachments/899462124445790261/1403473036912361502/image.png?ex=6897ad9f&is=68965c1f&hm=595ef73a2fc6da99e68d0fe7827242b446cddd5601244db844e8652f1c0f3701&=&format=webp&quality=lossless)

# Correcciones

**Linea 3:** De "using System.ComponentModel.DataAnnotations;" a "using System;"

![Evidencia](https://cdn.discordapp.com/attachments/899462124445790261/1403483154282713220/image.png?ex=6897b70b&is=6896658b&hm=0921a27d7c8e4786e3f9a1f4deddaac78b770b891e5c55e8f7a185dd79368cd1&)