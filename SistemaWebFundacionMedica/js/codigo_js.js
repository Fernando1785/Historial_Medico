
 function cancelClick() {
        
 }
	
function calculaEdad()
{
	var fecha = null;
	fecha = document.getElementById(txtFechaM).value;
	
	var edad = null;
	edad = calcular_edad(fecha);
	if (edad != false)
	{
		document.getElementById(txtEdadM).value = edad;
	}
	//document.getElementById(txtEdadM).value = fecha;
}

//calcular la edad de una persona 
//recibe la fecha como un string en formato español 
//devuelve un entero con la edad. Devuelve false en caso de que la fecha sea incorrecta o mayor que el dia actual 
function calcular_edad(fecha){ 

   	//calculo la fecha de hoy 
   	hoy=new Date();
   	//alert(hoy) 

   	//calculo la fecha que recibo 
   	//La descompongo en un array 
   	var array_fecha = fecha.split("/");
   	//si el array no tiene tres partes, la fecha es incorrecta 
   	if (array_fecha.length!=3)
      	 return false;

   	//compruebo que los anio, mes, dia son correctos 
   	var anio; 
   	anio = parseInt(array_fecha[2]); 
   	if (isNaN(anio))
      	 return false;

   	var mes; 
   	mes = parseInt(array_fecha[1]); 
   	if (isNaN(mes)) 
      	 return false;

   	var dia;
   	dia = parseInt(array_fecha[0]);	
   	if (isNaN(dia))
      	 return false;


   	//si el año de la fecha que recibo solo tiene 2 cifras hay que cambiarlo a 4 
   	if (anio<=99) 
      	 anio +=1900;

    //resto los años de las dos fechas
    var nuevoa = hoy.getFullYear();
    edad = nuevoa - anio - 1; //-1 porque no se si ha cumplido años ya este año 

   	//si resto los meses y me da menor que 0 entonces no ha cumplido años. Si da mayor si ha cumplido 
   	if (hoy.getMonth() + 1 - mes < 0) //+ 1 porque los meses empiezan en 0 
      	 return edad;
   	if (hoy.getMonth() + 1 - mes > 0) 
      	 return edad+1;

   	//entonces es que eran iguales. miro los dias 
   	//si resto los dias y me da menor que 0 entonces no ha cumplido años. Si da mayor o igual si ha cumplido 
   	if (hoy.getUTCDate() - dia >= 0) 
      	 return edad + 1;

   	return edad;
}



function validar_dato() {
    //alert(valor);
    var cedula = null;
    cedula = document.getElementById(txtCedulam).value;
    if (!valida_Cedu_Ruc(cedula)) {
        mensaje = "Numero de Ruc o Cedula invalido";
        alert(mensaje);
        document.getElementById(txtCedulam).value = '';
        document.getElementById(txtCedulam).focus();
    }

}

function valida_Cedu_Ruc(valor) {
    var tercer = "";
    tercer = valor.substring(2, 3);
    var tam = valor.length;
    if (tercer == 9) {//RUC para Sociedades Privadas y Extranjeros sin cédula:
        if (tam != 13) {
            alert("Numero Invalido, numero de Ruc debe tener 13 digitos");
            return false;
        }
        var arr_verificador = new Array();
        //4.3.2.7.6.5.4.3.2 
        arr_verificador[0] = 4;
        arr_verificador[1] = 3;
        arr_verificador[2] = 2;
        arr_verificador[3] = 7;
        arr_verificador[4] = 6;
        arr_verificador[5] = 5;
        arr_verificador[6] = 4;
        arr_verificador[7] = 3;
        arr_verificador[8] = 2;
        result = 0;
        for (i = 0; i < 9; i++) {
            result = (arr_verificador[i] * (valor.substring(i, i + 1) * 1)) * 1 + result;
        }
        resid = result % 11;
        //alert(resid);
        if (resid == 0)
            verificador = 0;
        else
            verificador = 11 - resid;
        if (verificador != (valor.substring(9, 10) * 1)) {
            alert("digito verificador incorrecto");
            return false;
        }
        if ((valor.substring(0, 2) * 1) > 24) {
            alert("Primeros digitos erroneos");
            return false;
        }
        //alert(valor.substring(10,13));
        return true;

    }
    if (tercer == 6) {//RUC para Sociedades Públicas:
        if (tam != 13) {
            alert("Numero Invalido, numero de Ruc debe tener 13 digitos");
            return false;
        }
        var arr_verificador = new Array();
        //3.2.7.6.5.4.3.2 
        arr_verificador[0] = 3;
        arr_verificador[1] = 2;
        arr_verificador[2] = 7;
        arr_verificador[3] = 6;
        arr_verificador[4] = 5;
        arr_verificador[5] = 4;
        arr_verificador[6] = 3;
        arr_verificador[7] = 2;
        result = 0;
        for (i = 0; i < 8; i++) {
            result = (arr_verificador[i] * (valor.substring(i, i + 1) * 1)) * 1 + result;
        }
        resid = result % 11;
        //alert(resid);
        if (resid == 0)
            verificador = 0;
        else
            verificador = 11 - resid;
        if (verificador != (valor.substring(8, 9) * 1)) {
            alert("digito verificador incorrecto");
            return false;
        }
        if ((valor.substring(0, 2) * 1) > 24) {
            alert("Primeros digitos erroneos");
            return false;
        }
        //alert(valor.substring(10,13));
        return true;
    }
    if (tercer <= 5) {//RUC para Personas Naturales o cedula:

        //
        if (tam != 13 && tam != 10) {
            alert("Numero Invalido, numero de Ruc o cedula debe tener 13 o 10 digitos");
            return false;
        }
        var arr_verificador = new Array();
        //2.1.2.1.2.1.2.1.2
        arr_verificador[0] = 2;
        arr_verificador[1] = 1;
        arr_verificador[2] = 2;
        arr_verificador[3] = 1;
        arr_verificador[4] = 2;
        arr_verificador[5] = 1;
        arr_verificador[6] = 2;
        arr_verificador[7] = 1;
        arr_verificador[8] = 2;
        result = 0;
        for (i = 0; i < 9; i++) {
            val = (arr_verificador[i] * (valor.substring(i, i + 1) * 1)) * 1;
            if (val >= 10) {
                val = "" + val;
                result = ((val.substring(0, 1) * 1) + (val.substring(1, 2) * 1)) * 1 + result;
            }
            else {
                result = val + result;
            }

        }
        //alert(result);
        resid = result % 10;
        //alert(resid);
        if (resid == 0)
            verificador = 0;
        else
            verificador = 10 - resid;
        //alert(verificador);
        if (verificador != (valor.substring(9, 10) * 1)) {
            alert("digito verificador incorrecto");
            return false;
        }
        if ((valor.substring(0, 2) * 1) > 24) {
            alert("Primeros digitos erroneos");
            return false;
        }
        if (valor.substring(10, 13) != "001" && tam == 13) {
            //alert(valor.substring(10,13));
            alert("Ultimos digitos deben ser 001");
            return false;
        }

        //alert(valor.substring(10,13));
        return true;

    }
    else {
        //alert("Numero de Ruc o Cedula invalido");
        return false;
    }


}









function llamarListaEspecilidad()
{
	location.href='frmWebListaEspecialidades.aspx';
}

function llamarListaPacienteNuevo()
{
	location.href='frmWebMantenimientoPaciente.aspx';
}

function NuevoPaciente()
{
var edad = null;
edad = document.getElementById(txtedad).value;
	if (edad =='' || edad == null)
	{
		alert("Debe ingresar la edad");
	}
	else
	{
		alert('entro');
		var opcion = "guardar"
		location.href='frmWebMantenimientoPaciente.aspx?parametro='+opcion;
	}
}


function desbloquearPaciente()
{
	document.getElementById(txtApellido).disabled=false;
	document.getElementById(txtCedula).disabled=false;
	document.getElementById(txtNombre).disabled=false;
	document.getElementById(txtedad).disabled=false;
	document.getElementById(txtsexo).disabled=false;
	document.getElementById(fecha).disabled=false;
	document.getElementById(txtDirec).disabled=false;
	document.getElementById(txttelf).disabled=false;
	document.getElementById(txtCelular).disabled=false;
}


function nuevoTurno()
{
var turno = null;
turno = document.getElementById(txtIdTurno).value;
	if (turno =='' || turno == null)
	{
		alert("Debe ingresar el TURNO");
	}
	else
	{
		alert('entro');
		var opcion = "guardar"
		location.href='FrmWebMantenimientoTurno.aspx?parametro='+opcion;
	}
}

function getEspecialidad()
{
   var numticket = document.getElementById("numticket").value;
       new Request(
	   {
	        method: 'post',
	        url: 'consultas.aspx',
			onSuccess: function(responseText,responseXML){
			    if(responseText)
			    { 
			      document.getElementById("tablaAsignaciones").innerHTML = responseText;
			      //alert(responseText);
			      //window.setTimeout("cargardata()",500);
			    }
			},
			onFailure: function(responseText,responseXML){
			    alert("Error en la Aplicacion");
		    }	        
	    }
	    ).send("numticket="+numticket+"&param=Asignaciones"); 


}




function nuevoTurnoAJAX()
{
var turno = null;
turno = document.getElementById(txtIdTurno).value;
	
	new Request(
	{
	method: 'post',
	url: 'consultas.aspx',
	onSuccess: function(responseText,responseXML){
	   // alert(val + " vs " + responseText);
	    if(val != responseText)
	    {
	        if(document.getElementById('creandoTicket'))
	        {
	            if(document.getElementById('creandoTicket').value!="true")	        
	                location.reload(true);
	        }
	        else
	            location.reload(true);
	    }
	    else
		    window.setTimeout("chequeaAct()",2000);
	},
    onFailure: function(responseText,responseXML){
        //alert('Error en la aplicación');
        window.setTimeout("chequeaAct()",2000);
        //alert('Error en la aplicación');
    }
	}).send('param=getMaxCallId');
}



