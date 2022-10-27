export default async function decorate(block) {
  const slides = [...block.children];
  slides.forEach((slide) => {
    const overlay = document.createElement('div');
    overlay.classList.add('slideshow-overlay');
    [...slide.firstElementChild.children].forEach((child) => {
      if (child.nodeName !== 'PICTURE' && !child.querySelector('picture')) {
        overlay.append(child);
        if (child.querySelector('a')) {
          const a = child.querySelector('a');
          if (a.textContent === child.textContent) {
            a.classList.add('btn', 'slideshow-btn');
            child.classList.add('slideshow-btn-wrapper');
          }
        }
      } else if (child.querySelector('picture')) {
        child.outerHTML = child.outerHTML.replace('<p>', '').replace('</p>', '');
        slide.firstElementChild.classList.add('slideshow-img');
      }
      slide.classList.add('slideshow-slide');
    });
    if (overlay.children) {
      slide.append(overlay);
    }
  });

  // setup for multiple slides
  if (slides.length > 1) {
    // duplicate first slide at the end of the slideshow to create illusion of endless loop
    block.append(slides[0].cloneNode(true));

    let index = 0;
    console.log('index txt' + index);
    setInterval(() => {

      
      // remove heading animations
      block.querySelectorAll('span.slideshow-reveal').forEach((span) => {
        span.classList.remove('slideshow-reveal');
      });
      
      if (block.scrollWidth - block.scrollLeft > block.offsetWidth) {
        

      if (index < slides.length) {
        // next slide
        block.classList.add('slideshow-transition');
        block.scrollLeft += block.offsetWidth;

      } else {
        
        // back to start
        index = 0;
        block.scrollLeft = 0;
        
      }
      // add next heading animation
      block.children[index].querySelectorAll('span').forEach((span) => {
        span.classList.add('slideshow-reveal');
      });
    }, 1000);

        index += 1;
        setTimeout(() => {
          block.classList.remove('slideshow-transition');
          // check if last slide
          if (index === slides.length) {
            // quietly sneak back to start
            block.scrollLeft = 0;
            index = 0;
          }
        }, 1000);
      }
    }, 7000);
    
    window.addEventListener('resize', () => {
      block.scrollLeft = 0;
      index = 0;
    });
  }
}
