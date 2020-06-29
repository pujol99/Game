varying vec3 v_position;
varying vec3 v_world_position;
varying vec3 v_normal;
varying vec2 v_uv;
varying vec4 v_color;

uniform vec3 u_camera_pos;
uniform vec4 u_color;
uniform sampler2D u_texture;
uniform float u_time;
uniform float u_texture_tiling;
uniform vec3 u_light_direction;

void main()
{
	vec2 uv = v_uv;
	vec4 color = u_color * texture2D( u_texture, uv);
	vec3 N = normalize(v_normal);
	vec3 L = normalize(u_light_direction);
	float NdotL = clamp(dot(N, L), 0.0, 1.0);
	vec3 light = NdotL * vec3(1.0, 1.0, 1.0) * 0.7;
	light += vec3(0.8, 0.8, 0.8);
	color.xyz *= light;

	float dist = length(v_world_position - u_camera_pos);
	dist = clamp(dist / 250.0, 0.0, 1.0);

	vec3 fog_color = vec3(0.0, 0.0, 0.0);
	color.xyz = mix(color.xyz, fog_color, dist);

	gl_FragColor = color;
}
