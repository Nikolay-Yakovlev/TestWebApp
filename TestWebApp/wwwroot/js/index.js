$(document).ready(

function () {

	

	var employees = ajaxgetdata('/home/DisplayEmployeesList');
	var professions = ajaxgetdata('/home/DisplayProfessionsList');

	employees.forEach(function (empl, i, result) {
		$('#empltable > tbody:last-child').append('<tr>'
		+ '<td>' + empl.name + ' ' + empl.lastName +' ' + (empl.patronymic || '') + '</td>' 
		+ '<td>' + convertdate(empl.dateOfBirth) + '</td>'
			+ '<td>' + getProfName(empl.professionID) +'</td>'
		+ '<td>'
			+ '<div>'
			+ '<a href="/home/edit/'+empl.id+'">Edit</a> / '
			+ '<a href="/home/delete/'+empl.id+'">Delete</a> '
			+'</div>'
		+ '</td></tr>'
		);
	

	});
	

		function getProfName(i) {
			var r = professions.find(obj => {
				return obj.id === i
			})

			return (r.profession)
		};


function ajaxgetdata(urlstring){
		var result;
		$.ajax({
			url: urlstring,
			type: 'POST',
			async: false,
			dataType: 'html',
			success: function (response) {
				result = ($.parseJSON(response));
			}
		});
		return result;
};		

function convertdate(inputFormat) {
  function pad(s) { return (s < 10) ? '0' + s : s; }
  var d = new Date(inputFormat)
  return [pad(d.getDate()), pad(d.getMonth()+1), d.getFullYear()].join('-')
}


}
);