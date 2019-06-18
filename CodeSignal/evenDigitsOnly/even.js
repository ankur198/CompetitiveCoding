function evenDigitsOnly(n){
    for (let i = 0; i < n.toString().length; i++) {
        const element = n.toString()[i];
        if(parseInt(element)%2!=0) return false
    }
    return true
}

console.log(evenDigitsOnly(2446))