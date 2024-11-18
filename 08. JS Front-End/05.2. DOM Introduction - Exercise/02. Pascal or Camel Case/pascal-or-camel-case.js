function solve() {
  const text = document.getElementById('text').value;
  const namingConvention = document.getElementById('naming-convention').value;

  let result = '';
  const words = text.split(' ').map(x=>x.toLowerCase());

  if(namingConvention === 'Pascal Case') {
    
    for(let i = 0; i < words.length; i++){
      result += capitalizeFirstLetter(words[i]);
    }

  }else if (namingConvention === 'Camel Case'){
    result += words[0];

    for(let i = 1; i < words.length; i++){
      result += capitalizeFirstLetter(words[i]);
    }

  } else {
    result = 'Error!';
  }

  document.getElementById('result').innerText = result;

  function capitalizeFirstLetter([ first='', ...rest ]) {
    return [ first.toUpperCase(), ...rest ].join('');
  }
}