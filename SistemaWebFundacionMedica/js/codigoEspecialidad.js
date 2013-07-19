function nuevaEspe()
{
	document.getElementById(tblIngresoEspe).style.display = "block";
	
}

function guardaEspe()
{
var espe = document.getElementById(txtNombreEspecilidad).value;
  new Request(
	   {
	        method: 'post',
	        url: 'frmWebAjaxEspecialidad.aspx',
			onSuccess: function(responseText,responseXML){
			    if(responseText)
			    { 
				//alert(responseText);
					if (responseText != "" && responseText != null)
					{
					alert('Especialidad Ingresada');
					//cargaGrilla();
					
					}
					else
					{
					alert('no guardo');
					}
			    }
			},
			onFailure: function(responseText,responseXML){
			    alert("Error en la Aplicacion");
		    }	        
	    }
	    ).send("especialidad="+espe+"&param=guardar"); 
}

function cargaGrilla()
{	
	location.href='frmEspecialidad.aspx';
	  /*new Request(
	   {
	        method: 'post',
	        url: 'frmWebListaEspecialidades.aspx',
			onSuccess: function(responseText,responseXML){
			   alert('Especialidad Ingresada');
			    
			},
			onFailure: function(responseText,responseXML){
			    alert("Error en la Aplicacion");
		    }       
	    }
	    ).send('param=cargarGrilla'); */
}

function guardaEspeDirecto()
{
var espe = document.getElementById(txtNombreEspecilidad).value;
var msn = null;
var valida = false;

if (espe != "" && espe != null)
{

}
		if (valida)
		{
		  new Request(
			   {
					method: 'post',
					url: 'frmEspecialidad.aspx',
					onSuccess: function(responseText,responseXML){
						if(responseText)
						{ 
						//alert(responseText);
							if (responseText != "" && responseText != null)
							{
							
							cargaGrilla();
							
							}
							else
							{
							alert('no guardo');
							}
							
						}
					},
					onFailure: function(responseText,responseXML){
						alert("Error en la Aplicacion");
					}	        
				}
				).send("especialidad="+espe+"&param=guardar"); 
		}
}
