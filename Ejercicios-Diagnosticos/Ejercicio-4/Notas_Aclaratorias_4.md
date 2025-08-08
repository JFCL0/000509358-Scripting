# Enunciado

Implemente lo siguiente:
- Una clase abstracta AbstractSample con los siguientes elementos:  

        1) Un atributo privado message,   
        2) Un método abstracto PrintMessage  
        3) Un método virtual InvertMessage.  
            a) Ambos métodos reciben un string como parámetro.  
            b) InvertMessage invierte message  

- Dos subclases de AbstractSample (nombres a su discresión):  

        1) Una implementa PrintMessage imprimiendo message  
        2) Otra implementa PrintMessage imprimiendo message con mayúsculas y minúsculas invertidas.  
        3) Una de las clases sobreescribe InvertMessage para que, además de lo que hace, cambie mayúsculas por minúsculas.  


# Feedback

- El código de las clases no compila - faltó agregar la librería System, que permite el uso de funciones como la lectura y escritura en consola.
- El último ejercicio no tiene un Main para probarlo.
- Para qué importar la librería de Threading? Aquí no hay programación en paralelo.
- Esos nombre de clases qué? Hay que empezar a escribir código correctamente.
- Las sobrecargas de PrintMessage no están implementadas correctamente - lo primero que hacen es tirar una excepción, por lo que no ejecutan lo que se supone que van a hacer.
- A estas alturas es inaceptable no correr un código para ver si hace lo que se supone que debe. Un run bastaba para ver casi todo lo que anoté acá, salvo por los nombres de clases. (0.0 / 1.25)

# Notas aclaratorias

Primero lo primero, y lo que es lo mas relevante en lo que concierne a la solución del ejercicio y su **inhabilidad para poder compilarse**. En ese aspecto, supongo realmente no tengo excusa, ya que la investigación que hice alrededor de los **Metodos Abstractos** probó ser deficiente. Dialogando con varios de mis compañeros de clase, parece ser un problema en común no conocer acerca de estos metodos, ya que en ninguno de los dos cursos previos a el presente, siendo estos **Programación orientada a objetos** y **Sistemas Computacionales** exploramos este concepto.  

Debido a que la investigación que realicé expresaba abiertamente que los **Metodos Abstractos** no se veian en la obligación de ser definidos, **supuse** que, por defecto, estos generalmente llevarian a que al momento de depurar el codigo, este, inherentemente, siempre daria un resultado como defectuoso. Acepto, eso fue una evidente **falta de comprensión de mi parte**, por lo que me permito solicitar una explicación, asi sea en corto, de este tema, ya que he confirmado que no soy el unico con poco o nulo conocimiento de este tipo de clases y metodos.  

Ahora, en lo que concierne el **nombre de las sub-clases**, en el nuevo codigo enviado he añadido, en forma de *comentarios en el codigo* (de manera que no se considere un cambio no requerido para poder depurar el codigo), posibles reemplazos a estos, ya que **fallaron en comunicar el motivo de existencia de la clase en si misma**.

**A su vez, he de admitir, soy un poco idiota y olvide completamente agregar el codigo escrito en "Program.cs" cuando estaba poniendo las respectivas partes del programa en el archivo "Ejercicio4.cs", fue un error estupido, y pido disculpas por pasar por alto algo que realmente es tan crucial.**

Adjunto evidencia de que el archivo del codigo original no ha sido modificado, y la presencia del apartado "Program.cs".

![Evidencia_Fecha](https://cdn.discordapp.com/attachments/899462124445790261/1403490654104981524/image.png?ex=6897be07&is=68966c87&hm=bbf25234216d5732e392a5e0179d1e5e716bb054cb81c9e7ff731e1b80b09240&)

![Evidencia_Program](https://cdn.discordapp.com/attachments/899462124445790261/1403490654360703137/image.png?ex=6897be07&is=68966c87&hm=d16782e442a9f31914968256511f73316870b8d09b652eb3aafc83ac57a5150f&)

# Correcciones

**Program.cs:** Es ahora evidente su presencia en el codigo, conteniendo a su vez el metodo Main.
**Linea 1 de Program:** Agregar "using System;", que no estaba en el archivo sln original del ejercicio.
**Linea 5 de AbstractSample, GodKillMeSample, HuhSample y MessageManager:** Remove "using Threading".
**Linea 9 de GodKillMeSample:** *Sugerencia posible cambio de nombre de la clase a "aBSTRACTsAMPLE" (AbstractSample con mayusculas invertidas).*
**Linea 9 de HuhSample:** *Sugerencia posible cambio de nombre de la clase a ELPMAsTCARTSBa (AbstractSample con mayusculas y letras invertidas).*
**Linea 13 de HuhSample y GodKillMeSample:** Remove "throw new NotImplementedException();"
**Linea 11 de MessageManager:** *Sugerencia posible cambio de nombre de "WhatAmIDoing()" a "SendMessage()"*

Evidencia del funcionamiento del programa:

![Evidencia](https://cdn.discordapp.com/attachments/899462124445790261/1403481527194746971/image.png?ex=6897b587&is=68966407&hm=c90c33377bb59949f7628831e8a3c344708269ec9904acdc98750e4cdc8922f6&)