function Afficher() {

    if (document.getElementById('Client').checked) {
        document.getElementById('cl').style.display = 'block';
        document.getElementById('cd').style.display = 'none';
        document.getElementById('rs').style.display = 'none';

    }


}
function Afficher2() {

    if (document.getElementById('Candidate').checked) {
        document.getElementById('cd').style.display = 'block';
        document.getElementById('cl').style.display = 'none';
        document.getElementById('rs').style.display = 'none';


    }
}
function Afficher3() {

    if (document.getElementById('Resource').checked) {
        document.getElementById('rs').style.display = 'block';
        document.getElementById('cl').style.display = 'none';
        document.getElementById('cd').style.display = 'none';

    }



}