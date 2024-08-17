// On page load or when changing themes, best to add inline in `head` to avoid FOUC
function applier() {
  if (
    localStorage.getItem("color-theme") === "dark" ||
    (!("color-theme" in localStorage) &&
      window.matchMedia("(prefers-color-scheme: dark)").matches)
  ) {
    document.documentElement.classList.add("dark");
  } else {
    document.documentElement.classList.remove("dark");
  }
}

applier();

function initClickOutside() {
  const div = document.getElementById('search-overlay');

  document.addEventListener('click', e => {
    if (!div.contains(e.target) && div.innerHTML.trim()) div.innerHTML = '';
  });

  document.addEventListener('keydown', e => {
    if (e.key === 'Escape' && div.innerHTML.trim()) div.innerHTML = '';
  });
}

