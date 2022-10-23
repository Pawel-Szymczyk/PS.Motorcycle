
	//window.addEventListener("load", function(){
	//	let content = document.getElementsByClassName('motorcycles-list');
	//	let elementToHide = content[0].children[0];
	//	//console.log(content);
	//	//console.log(elementToHide);

	//	elementToHide.style.display = 'none';
	//	{/*[0].style.display = 'none';*/}
	
	//});


//export function hideElement() {
//		let content = document.getElementsByClassName('motorcycles-list');
//		let elementToHide = content[0].children[0];
//		console.log(content);
//		console.log(elementToHide);

//		elementToHide.style.display = 'none';
//}



  window.hideElement = () => {
		let content = document.getElementsByClassName('motorcycles-list');
		let elementToHide = content[0].children[0];
		console.log(content);
		console.log(elementToHide);

		elementToHide.style.display = 'none';
  };
