from django import forms

#Formulario para Eliminar Peliculas
class FormularioPeliculas(forms.Form):
    Titulo = forms.CharField()
    Categoria = forms.IntegerField(required=False)
    Descripcion = forms.CharField(required=False)
    Duracion = forms.IntegerField(required=False)
    Fecha = forms.CharField(required=False)
    Precio = forms.FloatField(required=False)

#REGISTRAR VENTA DE PELICULAS
class FormularioPeliculas3(forms.Form):
    Precio = forms.IntegerField()
    Cliente = forms.CharField()
    Correo = forms.EmailField()
    Fecha= forms.CharField()
    Precio = forms.FloatField()
    IdPelicula = forms.IntegerField()

    # Formulario para Agregar Peliculas
class FormularioPeliculas2(forms.Form):
    Titulo = forms.CharField()
    Categoria = forms.IntegerField()
    Descripcion = forms.CharField()
    Duracion = forms.IntegerField()
    Fecha = forms.CharField()
    Precio = forms.FloatField()

#Formulario para eliminar juego
class FormularioJuegos(forms.Form):
   # id = forms.IntegerField(required=False, disabled=False)
    Titulo = forms.CharField()
    Categoria = forms.IntegerField(required=False)
    Descripcion = forms.CharField(required=False)
    Clasificacion = forms.CharField(required=False)
    Fecha = forms.CharField(required=False)
    Precio = forms.FloatField(required=False)

#Formulario para agregar juego
class FormularioJuegos2(forms.Form):
    Titulo = forms.CharField()
    Categoria = forms.IntegerField()
    Descripcion = forms.CharField()
    Clasificacion = forms.IntegerField()
    Fecha = forms.CharField()
    Precio = forms.FloatField()

#REGISTRAR VENTA DE JUEGO
class FormularioJuegos3(forms.Form):
   # id = forms.IntegerField(required=False, disabled=False)
    Precio = forms.FloatField()
    Cliente = forms.CharField()
    Correo = forms.EmailField()
    Fecha = forms.CharField()
    IdJuego = forms.IntegerField()



#INSERCION DE ESTRENOS
class FormularioEstrenos(forms.Form):
    Titulo = forms.CharField()
    Descripcion = forms.CharField()
    Tipo= forms.CharField()

