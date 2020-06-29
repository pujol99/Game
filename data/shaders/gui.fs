varying vec3 v_position;
varying vec3 v_world_position;
varying vec3 v_normal;
varying vec2 v_uv;
varying vec4 v_color;

uniform vec4 u_color;
uniform sampler2D u_texture;
uniform float u_time;
uniform vec4 u_text_range; //[x, y, w, h]

void main(){
	vec2 uv = v_uv;
	uv.x = (u_text_range.z) * uv.x + u_text_range.x;
	uv.y = 1.0 - ((-u_text_range.w) * uv.y + u_text_range.y + u_text_range.w);

	vec4 color = u_color * texture2D(u_texture, uv);
	if (color.a <= 0.0)
		discard;
	gl_FragColor = color;
}